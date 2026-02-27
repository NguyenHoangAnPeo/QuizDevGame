using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : AnMonoBehaviour
{
    protected static SaveManager instance;
    public static SaveManager Instance => instance;
    [SerializeField] protected string savePath;
    public SaveData saveData = new SaveData();
    protected override void Awake()
    {
        base.Awake();
        if(SaveManager.instance == null)
        {
            SaveManager.instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/save.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public virtual void SaveGame()
    {
        string jsonSave = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, jsonSave);
    }
    public virtual void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            //saveData = JsonUtility.FromJson<SaveData>(json);
            var loaded = JsonUtility.FromJson<SaveData>(json);
            saveData = loaded ?? new SaveData();
            if (saveData.listSubjScoreSave == null) saveData.listSubjScoreSave = new List<SaveDataSubject>();
        }
    }
    public void SaveScore(string subjectName, int score)
    {
        SaveDataSubject saveDataSubject = saveData.listSubjScoreSave
            .Find(x => x.subjectName == subjectName);

        if (saveDataSubject == null)
        {
            saveDataSubject = new SaveDataSubject
            {
                subjectName = subjectName,
                scoreSubj = score
            };

            saveData.listSubjScoreSave.Add(saveDataSubject);
        }
        else
        {
            saveDataSubject.scoreSubj = Mathf.Max(saveDataSubject.scoreSubj, score);
        }

        this.SaveGame(); // ghi file JSON
    }
}
