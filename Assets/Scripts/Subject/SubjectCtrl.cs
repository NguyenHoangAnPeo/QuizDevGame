using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SubjectCtrl : AnMonoBehaviour
{
    [SerializeField] protected SubjectBtn subjectBtn;
    public SubjectBtn SubjectBtn => subjectBtn;

    [SerializeField] protected SubjectConfigSO subjectConfig;
    public SubjectConfigSO SubjectConfigSO => subjectConfig;

    [SerializeField] protected InitBtnData initBtnData;
    public InitBtnData InitBtnData => initBtnData;

    [SerializeField] protected string jsonName;
    public string JsonName => jsonName;

    [SerializeField] protected int levelSubject;
    public int LevelSubject => levelSubject;

    [SerializeField] protected int score;

    public bool IsUnlock = false;

    protected override void Start()
    {
        base.Start();
        //this.ResetLevel();
        this.SetUnlockedLevel();
        this.SetSubjBtnInteractable();
    }
    protected virtual void SetUnlockedLevel()
    {
        if (QuizResultManager.Instance == null) return;
        this.score = QuizResultManager.Instance.GetScore(jsonName);
        
        if (score >= 5)
        {
            int unlockedLevel = this.levelSubject + 1; //neu qua level hien tai thi man mo khoa la cai tiep theo
            string levelMajorName = MajorManager.Instance.MajorSO.majorName; // Set level bang ten Nganh

            LevelManager.Instance.SetLevelSubj(levelMajorName, unlockedLevel);

            Debug.Log("Current UnlockedLevel = " + unlockedLevel);
        }
        return;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubjectBtn();
        this.LoadInitBtnData();
    }
    protected virtual void LoadInitBtnData()
    {
        if (this.initBtnData != null) return;
        this.initBtnData = transform.GetComponentInChildren<InitBtnData>();
    }
    protected virtual void LoadSubjectBtn()
    {
        if (this.subjectBtn != null) return;
        this.subjectBtn = transform.GetComponentInChildren<SubjectBtn>();
    }
    protected virtual void LoadJsonName()
    {
        if (this.subjectConfig == null) return;

        this.jsonName = subjectConfig.subjectName;
        Debug.Log("jsonName : " + jsonName);
    }
    public virtual void InitSubjectData(string folderMajorName, string configSOName ,int levelSubj) //folderMajorName chua subject cua rieng nganh do
    {
        if (this.subjectConfig != null) return;
        this.subjectConfig = Resources.Load<SubjectConfigSO>("SubjectConfig/" + folderMajorName + "/" + configSOName);

        this.LoadJsonName();
        initBtnData.InitData(subjectConfig.displayName,subjectConfig.subjectName);

        this.levelSubject = levelSubj;
    }
    protected virtual void SetSubjBtnInteractable()
    {
        string levelMajorName = MajorManager.Instance.MajorSO.majorName;
        int unlockedLevel = PlayerPrefs.GetInt(levelMajorName, 1);

        this.IsUnlock = levelSubject <= unlockedLevel;

        SubjectBtn.SetInteractable(IsUnlock);
    }
    protected virtual void ResetLevel()
    {
        string levelMajorName = MajorManager.Instance.MajorSO.majorName;

        LevelManager.Instance.SetLevelSubj(levelMajorName, 1);
    }
}
