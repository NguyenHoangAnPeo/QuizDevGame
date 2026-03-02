using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBtn : BaseBtn
{
    protected override void OnClick()
    {
        LevelManager.Instance.SetNextLevel();
        SceneManager.LoadScene("QuizScene");
    }
}
