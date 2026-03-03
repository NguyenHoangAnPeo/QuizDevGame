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
    public Subject CurrentSubject => currentSubject;
    [SerializeField] protected List<Question> questions;
    [SerializeField] protected int currentIndex;
    [SerializeField] protected int score = 0;
    [SerializeField] protected string subjectName;
    public int Score => score;

    [SerializeField] protected EnumResult enumResult;
    public EnumResult EnumResult => enumResult;

    protected override void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    protected override void Start()
    {
        provider = new StreamingJsonQuizProvider();
        this.subjectName = QuizData.subjectName;
        string majorNameFolder = MajorManager.Instance.MajorSO.majorName;
        this.StartQuiz(subjectName, majorNameFolder);
    }
    public async void StartQuiz(string subjectName, string majorNameFolder)
    {
        this.score = 0;
        currentSubject = await provider.LoadSubject(subjectName, majorNameFolder);

        PrepareQuestions();
        ShowCurrentQuestion();

        GameStateManager.Instance.SetState(GameState.PlayingQuiz);
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
        if(correct)score++;

        currentIndex++;
        if (currentIndex < questions.Count)
        {
            ShowCurrentQuestion();
        }
        else
        {
            this.EndGame();
            Debug.Log("Quiz Finished");
        }
    }
    protected virtual void EndGame()
    {
        bool isWin = score >= 5;

        this.enumResult = isWin ? EnumResult.Win : EnumResult.Lose;

        QuizResultManager.Instance.SaveScore(this.subjectName, this.score);

        SaveManager.Instance.SaveScore(this.subjectName, this.score);

        GameStateManager.Instance.SetState(GameState.EndGame);
        return;
    }
}
