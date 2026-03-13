using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawn : AnMonoBehaviour
{
    [SerializeField] protected GameObject subjectName;

    protected GameObject obj;

    protected override void Start()
    {
        base.Start();
        this.SpawnPanelNameSubject(true);
    }
    public virtual void SpawnPanelNameSubject(bool value)
    {
        if (value)
        {
            this.SpawnPanel(subjectName);
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
