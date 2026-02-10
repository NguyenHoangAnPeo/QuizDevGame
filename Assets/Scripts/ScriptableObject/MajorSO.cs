using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/MajorSO")]
public class MajorSO : ScriptableObject
{
    public string majorName; // dung de lay du lieu
    public string majorNameDisplay; // dung de hien thi ra man hinh
    public List<SubjectData> listSubject;
}
