using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizResultManager : AnMonoBehaviour
{
    protected static QuizResultManager instance;
    public static QuizResultManager Instance => instance;

    private Dictionary<string, int> subjectScores = new();

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public virtual void SaveScore(string subject, int score)
    {
        subjectScores[subject] = score;
    }

    public virtual int GetScore(string subject)
    {
        return subjectScores.ContainsKey(subject)
            ? subjectScores[subject]
            : 0;
    }
}
