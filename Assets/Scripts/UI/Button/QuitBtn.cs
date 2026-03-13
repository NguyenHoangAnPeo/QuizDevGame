using UnityEngine;

public class QuitBtn : BaseBtn
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
