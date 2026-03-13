using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : BaseBtn
{
    protected override void OnClick()
    {
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        GameManager.Instance.EndTransitionScene();

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("MajorScene");
    }
}
