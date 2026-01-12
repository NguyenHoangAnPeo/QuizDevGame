using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class QuizManager : AnMonoBehaviour
{
    protected static QuizManager instance;
    public static QuizManager Instance => instance;

    [SerializeField] protected IQuizDataProvider provider;
    [SerializeField] protected Subject currentSubject;
    [SerializeField] protected List<Question> questions;
    [SerializeField] protected int currentIndex;
    [SerializeField] protected string subjectKey = "Programming";

    protected override void Awake()
    {
        QuizManager.instance = this;
    }
    protected override void Start()
    {
        provider = new StreamingJsonQuizProvider();
        this.StartQuiz(subjectKey);
    }
    public async void StartQuiz(string subjectKey)
    {
        currentSubject = await provider.LoadSubject(subjectKey);
        PrepareQuestions();
        ShowCurrentQuestion();
    }

    protected virtual void PrepareQuestions()
    {
        questions = currentSubject.questions
            .OrderBy(x => Random.value)
            .Take(10)
            .ToList();

        currentIndex = 0;
    }

    protected virtual void ShowCurrentQuestion()
    {
        QuizUICtrl.Instance.ShowQuestion(questions[currentIndex]);
    }

    public virtual void CheckAnswer(int index)
    {
        bool correct = questions[currentIndex].correctIndex == index;
        Debug.Log(correct ? "Correct" : "Wrong");

        currentIndex++;
        if (currentIndex < questions.Count)
        {
            ShowCurrentQuestion();
            Debug.Log("Current index: " + currentIndex);
        }
        else
        {
            this.EndGame();
            Debug.Log("Quiz Finished");
        }
    }
    protected virtual void EndGame()
    {
        GameStateManager.Instance.SetState(GameState.EndGame);
        return;
    }
}
