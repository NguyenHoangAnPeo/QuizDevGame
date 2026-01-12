using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : AnMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning($"[BaseBtn] LoadBtn {this.text.name} in {this.gameObject.name}");
    }
}