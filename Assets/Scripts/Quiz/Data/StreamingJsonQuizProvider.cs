using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class StreamingJsonQuizProvider : IQuizDataProvider
{
    public async Task<Subject> LoadSubject(string subjectKey)
    {
        string path = System.IO.Path.Combine(
            Application.streamingAssetsPath,
            "Json",
            $"{subjectKey}.json"
        );

        using UnityWebRequest request = UnityWebRequest.Get(path);
        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield(); //  async that

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed to load json: {request.error}");
            return null;
        }

        string json = request.downloadHandler.text;
        return JsonUtility.FromJson<Subject>(json);
    }
}
