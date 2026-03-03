using UnityEngine;
using UnityEngine.SceneManagement;

public class UIAnimCtrl : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainPanel;
    [SerializeField] protected RectTransform rectTransform;

    public void OnClickFadeOut()
    {
        mainPanel.interactable = false;
        mainPanel.blocksRaycasts = false;

        UITransitionService.Instance.FadeNormal(mainPanel, 1f, 0f);
    }
    public void OnClickPopUp()
    {
        mainPanel.interactable = false;
        mainPanel.blocksRaycasts = false;
        UITransitionService.Instance.ScalePop(rectTransform, Vector3.one * 0.8f, Vector3.one, 0.7f);
    }
}