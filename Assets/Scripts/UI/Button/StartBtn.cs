using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : BaseBtn
{
    protected override void OnClick()
    {
        this.OnClickStart();
    }
    public async void OnClickStart()
    {
        await Task.Delay(500); // 1000ms = 1 giây

        SceneManager.LoadScene("MajorScene");
    }
}
