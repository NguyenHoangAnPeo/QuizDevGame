using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/MajorSO")]
public class MajorSO : ScriptableObject
{
    public string majorName;
    public List<SubjectData> listSubject;
}
