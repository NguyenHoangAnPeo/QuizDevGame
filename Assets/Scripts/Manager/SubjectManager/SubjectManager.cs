using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectManager : AnMonoBehaviour
{
    [SerializeField] protected FactorySubject factorySubject;
    public FactorySubject FactorySubject => factorySubject;

    protected static SubjectManager instance;
    public static SubjectManager Instance => instance;

    [SerializeField] protected string configSOName;
    public string ConfigSOName => configSOName;

    [SerializeField] protected int subjectCount;
    public int SubjectCount => subjectCount;
    protected override void Start()
    {
        base.Start();
        this.CreateSubject();
    }
    protected virtual void CreateSubject()
    {
        int subjectCount = MajorManager.Instance.MajorSO.listSubject.Count;
        string folderMajorName = MajorManager.Instance.MajorSO.majorName;

        for (int i = 0; i < subjectCount; i++)
        {
            this.configSOName = MajorManager.Instance.MajorSO.listSubject[i].configSubjectName;
            factorySubject.Create(folderMajorName,configSOName,i+1);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if (SubjectManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        SubjectManager.instance = this;
    }
    public virtual void SetConfigSOName(string confName)
    {
        this.configSOName = confName;
    }
}
