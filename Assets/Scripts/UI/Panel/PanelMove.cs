using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using DG.Tweening;

public class PanelMove : AnMonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;

    protected override void Start()
    {
        base.Start();
        this.MovePanelByX();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRect();
    }
    protected virtual void LoadRect()
    {
        if (this.rectTransform != null) return;
        this.rectTransform = transform.GetComponent<RectTransform>();
    }
    public virtual void MovePanelByX()
    {
        rectTransform.DOKill();

        DOTween.Sequence()
            .Append(rectTransform.DOAnchorPosX(0f, 1f)
                .SetEase(Ease.OutCubic))

            .Append(rectTransform.DOAnchorPosX(2000f, 1f)
                .SetEase(Ease.InCubic)).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
    }
}
