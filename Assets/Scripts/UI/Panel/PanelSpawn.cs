using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawn : AnMonoBehaviour
{
    [SerializeField] protected GameObject truePanel;

    [SerializeField] protected GameObject falsePanel;

    protected GameObject obj;

    protected override void Start()
    {
        base.Start();
        this.SpawnPanelTrueFalse(true);
    }
    public virtual void SpawnPanelTrueFalse(bool value)
    {
        if (value)
        {
            this.SpawnPanel(truePanel);
        }
        else
        {
            this.SpawnPanel(falsePanel);
        }
    }
    protected virtual void SpawnPanel(GameObject gameObject)
    {
        this.obj = Instantiate(gameObject, transform);

        obj.SetActive(true);

        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(-2000, 0);  
    }
}
