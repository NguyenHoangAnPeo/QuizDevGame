using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveDataSubject
{
    public string subjectName;
    public int scoreSubj;
}
[Serializable]
public class SaveData
{
    public List<SaveDataSubject> listSubjScoreSave = new List<SaveDataSubject>();
}
