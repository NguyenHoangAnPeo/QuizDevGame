using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : BaseText
{

    public void SetScoreText(int score)
    {
        this.textMeshUI.text = score.ToString();
    }
}
