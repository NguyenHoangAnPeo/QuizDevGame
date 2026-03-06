using System;
using System.Collections;
using UnityEngine;

#if DOTWEEN_ENABLED
using DG.Tweening;
#endif

public static class UIAnimationUtil
{
    public static void PunchScale(MonoBehaviour host, Transform target, float strength = 0.08f, float duration = 0.14f)
    {
        if (target == null) return;

#if DOTWEEN_ENABLED
        target.DOKill();
        target.DOPunchScale(Vector3.one * strength, duration, 8, 0.8f);
#else
        host.StartCoroutine(PunchScaleRoutine(target, strength, duration));
#endif
    }

    public static void FadeCanvasGroup(MonoBehaviour host, CanvasGroup canvasGroup, float to, float duration, Action onComplete = null)
    {
        if (canvasGroup == null)
        {
            onComplete?.Invoke();
            return;
        }

#if DOTWEEN_ENABLED
        canvasGroup.DOKill();
        canvasGroup.DOFade(to, duration).OnComplete(() => onComplete?.Invoke());
#else
        host.StartCoroutine(FadeRoutine(canvasGroup, to, duration, onComplete));
#endif
    }

    public static void ScaleIn(MonoBehaviour host, Transform target, float duration = 0.18f)
    {
        if (target == null) return;

#if DOTWEEN_ENABLED
        target.DOKill();
        target.localScale = Vector3.one * 0.94f;
        target.DOScale(1f, duration).SetEase(Ease.OutBack);
#else
        host.StartCoroutine(ScaleInRoutine(target, duration));
#endif
    }

    private static IEnumerator PunchScaleRoutine(Transform target, float strength, float duration)
    {
        Vector3 original = target.localScale;
        Vector3 peak = original * (1f + strength);

        float half = duration * 0.5f;
        float time = 0f;
        while (time < half)
        {
            time += Time.unscaledDeltaTime;
            target.localScale = Vector3.Lerp(original, peak, time / half);
            yield return null;
        }

        time = 0f;
        while (time < half)
        {
            time += Time.unscaledDeltaTime;
            target.localScale = Vector3.Lerp(peak, original, time / half);
            yield return null;
        }

        target.localScale = original;
    }

    private static IEnumerator FadeRoutine(CanvasGroup canvasGroup, float to, float duration, Action onComplete)
    {
        float from = canvasGroup.alpha;
        float time = 0f;

        if (duration <= 0f)
        {
            canvasGroup.alpha = to;
            onComplete?.Invoke();
            yield break;
        }

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, time / duration);
            yield return null;
        }

        canvasGroup.alpha = to;
        onComplete?.Invoke();
    }

    private static IEnumerator ScaleInRoutine(Transform target, float duration)
    {
        Vector3 from = Vector3.one * 0.94f;
        Vector3 to = Vector3.one;
        target.localScale = from;

        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            target.localScale = Vector3.Lerp(from, to, time / duration);
            yield return null;
        }

        target.localScale = to;
    }
}
