using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : AnMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI textMeshUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.textMeshUI != null) return;
        this.textMeshUI = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning($"[BaseBtn] LoadBtn {this.textMeshUI.name} in {this.gameObject.name}");
    }
}