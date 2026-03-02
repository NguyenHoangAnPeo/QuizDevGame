using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : AnMonoBehaviour
{
    [SerializeField] protected static LevelManager instance;
    public static LevelManager Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if(LevelManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        LevelManager.instance = this;
    }
    public virtual void SetLevelSubj(string nameSubj, int levelCount)
    {
        PlayerPrefs.SetInt(nameSubj, levelCount);

        Debug.Log("Set Level :" + nameSubj + "/" + levelCount);
    }
    public virtual int GetUnlockedLevel(string levelSubjName)
    {
        int unlockedLevel = PlayerPrefs.GetInt(levelSubjName, 1);
        return unlockedLevel;
    }
    public virtual void SetNextLevel()
    {
        var major = MajorManager.Instance?.MajorSO;
        string current = QuizData.subjectName;
        int idx = major.listSubject.FindIndex(x => x.subjectConfigSO.subjectName == current);
        if (!CheckListSubject(major) || !CheckCurrentSubject(major,idx))
        {
            QuizData.subjectName = major.listSubject[idx + 1].subjectConfigSO.subjectName;
        }
    }
    protected virtual bool CheckListSubject(MajorSO major)
    {

        if (major == null || major.listSubject == null || major.listSubject.Count == 0)
        {
            return false;
        }
        else
            return true;
    }
    protected virtual bool CheckCurrentSubject(MajorSO major,int idx)
    {

        if (idx < 0 || idx + 1 >= major.listSubject.Count)
        {
            return false;
        }
        else
            return true;
    }
}
