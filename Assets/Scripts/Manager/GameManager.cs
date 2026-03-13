using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startingSceneTransition;
    [SerializeField] GameObject endingSceneTransition;

    public static GameManager Instance;

    protected void Start()
    {
        this.StartTransitionScene();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartTransitionScene()
    {
        if (startingSceneTransition == null)
        {
            Debug.LogError("Start Transition chýa gán!");
            return;
        }

        startingSceneTransition.SetActive(true);
        Debug.Log("Da setactive StartTrans");
        Invoke(nameof(DisableStartingTrans), 2f);
    }

    void DisableStartingTrans()
    {
        startingSceneTransition.SetActive(false);
    }
    public void EndTransitionScene()
    {
        if (endingSceneTransition == null)
        {
            Debug.LogError("Start Transition chýa gán!");
            return;
        }

        endingSceneTransition.SetActive(true);
        Invoke(nameof(DisableEndingTrans), 2f);
    }

    void DisableEndingTrans()
    {
        endingSceneTransition.SetActive(false);
    }
}