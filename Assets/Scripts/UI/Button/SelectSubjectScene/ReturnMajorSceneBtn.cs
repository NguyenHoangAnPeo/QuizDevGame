using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMajorSceneBtn : BaseBtn
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("MajorScene");
    }
}
