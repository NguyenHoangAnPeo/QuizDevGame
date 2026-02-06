using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorManager : MonoBehaviour
{
    [SerializeField] protected MajorSO majorSO;
    public MajorSO MajorSO => majorSO;
    protected static MajorManager instance;
    public static MajorManager Instance => instance;

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public virtual void SetMajorSO(MajorSO majSO)
    {
        this.majorSO = majSO;
    }
}
