using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class LocalJsonQuizProvider : IQuizDataProvider
{
    public async Task<Subject> LoadSubject(string subjectKey)
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Json", $"{subjectKey}.json");
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<Subject>(json);
    }
}
