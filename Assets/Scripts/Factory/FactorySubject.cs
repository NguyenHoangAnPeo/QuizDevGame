using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySubject : AnMonoBehaviour
{
    [Header("Prefab")]

    [SerializeField] protected SubjectCtrl subjectCtrlPrefab;

    [SerializeField] protected Transform parent;

    protected override void Start()
    {
        base.Start();
        //this.Create("ProgrammingSubject",2);
    }
    public void Create(string configSOName,int subjectCount)
    {
        for(int i = 0; i < subjectCount; i++)
        {
            SubjectCtrl newSubject = Instantiate(subjectCtrlPrefab, this.parent);
            newSubject.transform.localScale = Vector3.one;

            newSubject.InitSubjectData(configSOName);
        }
    }
}
