using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance { get; private set; }

    private IQuizDataProvider provider;
    private Subject currentSubject;
    private List<Question> questions;
    private int currentIndex;

    private void Awake()
    {
        Instance = this;
        provider = new StreamingJsonQuizProvider();
    }

    public async void StartQuiz(string subjectKey)
    {
        currentSubject = await provider.LoadSubject(subjectKey);
        PrepareQuestions();
        ShowCurrentQuestion();
    }

    private void PrepareQuestions()
    {
        questions = currentSubject.questions
            .OrderBy(x => Random.value)
            .Take(10)
            .ToList();

        currentIndex = 0;
    }

    private void ShowCurrentQuestion()
    {
        QuizUICtrl.Instance.ShowQuestion(questions[currentIndex]);
    }

    public void Answer(int index)
    {
        bool correct = questions[currentIndex].correctIndex == index;
        Debug.Log(correct ? "Correct" : "Wrong");

        currentIndex++;
        if (currentIndex < questions.Count)
            ShowCurrentQuestion();
        else
            Debug.Log("Quiz Finished");
    }
}
