using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Subject Config")]
public class SubjectConfigSO : ScriptableObject
{
    public string subjectName;  // Programming
    public string displayName;  //Lap trinh
    public Sprite icon;
    public int passScore = 5;
}
