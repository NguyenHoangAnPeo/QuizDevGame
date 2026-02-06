using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorName : BaseText
{
    public virtual void SetMajorName(string majorName)
    {
        this.TextMeshProUGUI.text = majorName;
    }
}
