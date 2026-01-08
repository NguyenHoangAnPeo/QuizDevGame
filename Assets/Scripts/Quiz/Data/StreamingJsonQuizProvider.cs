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
            subjectKey + ".json"
        );

#if UNITY_EDITOR || UNITY_STANDALONE
        path = "file://" + path;   // Dong quyet dinh
#endif

        Debug.Log("JSON PATH = " + path);

        using UnityWebRequest request = UnityWebRequest.Get(path);
        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to load json: " + request.error);
            return null;
        }

        return JsonUtility.FromJson<Subject>(request.downloadHandler.text);
    }
}
