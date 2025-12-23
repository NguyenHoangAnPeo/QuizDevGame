using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionData
{
    public string question;
    public string[] answers; //size = 4
    [Range(0, 3)]
    public int correctIndex;
}
