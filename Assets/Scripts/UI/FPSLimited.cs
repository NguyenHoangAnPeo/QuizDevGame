using UnityEngine;

public class FPSLimited : MonoBehaviour
{
    public int targetFPS = 60;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
}
