using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
