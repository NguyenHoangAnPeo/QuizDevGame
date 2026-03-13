using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransitionService : AnMonoBehaviour
{
    protected readonly Dictionary<object, Coroutine> activeTransitions = new Dictionary<object, Coroutine>();

    protected const string AutoServiceName = "UITransitionService_Auto";
    protected static bool isCreatingAutoInstance;

    [Header("Scene Lifetime")]
    [SerializeField] protected bool persistAcrossScenes = true;

    [Header("Standard Duration")]
    [SerializeField] protected float quickDuration = 0.2f;
    public float QuickDuration => quickDuration;

    [SerializeField] protected float normalDuration = 0.35f;
    public float NormalDuration => normalDuration;

    [SerializeField] protected float slowDuration = 0.5f;
    public float SlowDuration => slowDuration;

    [Header("Default Curves")]
    [SerializeField] protected AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] protected AnimationCurve popCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] protected AnimationCurve slideCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    protected static UITransitionService instance;
    public static UITransitionService Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = FindObjectOfType<UITransitionService>();
            if (instance != null)
            {
                instance.ForcePersistAcrossScenes();
                return instance;
            }

            isCreatingAutoInstance = true;
            GameObject serviceObj = new GameObject(AutoServiceName);

            instance = serviceObj.AddComponent<UITransitionService>();
            isCreatingAutoInstance = false;

            instance.ForcePersistAcrossScenes();
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    protected static void Bootstrap()
    {
        _ = Instance;
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (persistAcrossScenes || isCreatingAutoInstance)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    protected virtual void ForcePersistAcrossScenes()
    {
        persistAcrossScenes = true;
        DontDestroyOnLoad(gameObject);
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public virtual Coroutine Fade(CanvasGroup canvasGroup, float from, float to, float duration, Action onCompleted = null)
    {
        return StartManagedTransition(canvasGroup, CoFade(canvasGroup, from, to, duration, fadeCurve, onCompleted));
    }

    public virtual Coroutine FadeQuick(CanvasGroup canvasGroup, float from, float to, Action onCompleted = null)
    {
        return Fade(canvasGroup, from, to, quickDuration, onCompleted);
    }

    public virtual Coroutine FadeNormal(CanvasGroup canvasGroup, float from, float to, Action onCompleted = null)
    {
        return Fade(canvasGroup, from, to, normalDuration, onCompleted);
    }

    public virtual Coroutine FadeSlow(CanvasGroup canvasGroup, float from, float to, Action onCompleted = null)
    {
        return Fade(canvasGroup, from, to, slowDuration, onCompleted);
    }

    public virtual Coroutine ScalePop(RectTransform rectTransform, Vector3 from, Vector3 to, float duration, Action onCompleted = null)
    {
        return StartManagedTransition(rectTransform, CoScale(rectTransform, from, to, duration, popCurve, onCompleted));
    }

    public virtual Coroutine ScalePopNormal(RectTransform rectTransform, Vector3 from, Vector3 to, Action onCompleted = null)
    {
        return ScalePop(rectTransform, from, to, normalDuration, onCompleted);
    }

    public virtual Coroutine Slide(RectTransform rectTransform, Vector2 from, Vector2 to, float duration, Action onCompleted = null)
    {
        return StartManagedTransition(rectTransform, CoSlide(rectTransform, from, to, duration, slideCurve, onCompleted));
    }

    public virtual Coroutine SlideNormal(RectTransform rectTransform, Vector2 from, Vector2 to, Action onCompleted = null)
    {
        return Slide(rectTransform, from, to, normalDuration, onCompleted);
    }

    protected virtual IEnumerator CoFade(CanvasGroup canvasGroup, float from, float to, float duration, AnimationCurve curve, Action onCompleted)
    {
        if (canvasGroup == null) yield break;

        canvasGroup.alpha = from;

        if (duration <= 0f)
        {
            canvasGroup.alpha = to;
            onCompleted?.Invoke();
            yield break;
        }

        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float progress = Mathf.Clamp01(time / duration);
            float evaluate = curve.Evaluate(progress);
            canvasGroup.alpha = Mathf.LerpUnclamped(from, to, evaluate);
            yield return null;
        }

        canvasGroup.alpha = to;
        onCompleted?.Invoke();
    }

    protected virtual IEnumerator CoScale(RectTransform rectTransform, Vector3 from, Vector3 to, float duration, AnimationCurve curve, Action onCompleted)
    {
        if (rectTransform == null) yield break;

        rectTransform.localScale = from;

        if (duration <= 0f)
        {
            if (rectTransform != null)
                rectTransform.localScale = to;

            onCompleted?.Invoke();
            yield break;
        }

        float time = 0f;

        while (time < duration)
        {
            if (rectTransform == null) yield break; 

            time += Time.unscaledDeltaTime;
            float progress = Mathf.Clamp01(time / duration);
            float evaluate = curve.Evaluate(progress);

            rectTransform.localScale = Vector3.LerpUnclamped(from, to, evaluate);

            yield return null;
        }

        if (rectTransform != null)
            rectTransform.localScale = to;

        onCompleted?.Invoke();
    }

    protected virtual IEnumerator CoSlide(RectTransform rectTransform, Vector2 from, Vector2 to, float duration, AnimationCurve curve, Action onCompleted)
    {
        if (rectTransform == null) yield break;

        rectTransform.anchoredPosition = from;

        if (duration <= 0f)
        {
            rectTransform.anchoredPosition = to;
            onCompleted?.Invoke();
            yield break;
        }

        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float progress = Mathf.Clamp01(time / duration);
            float evaluate = curve.Evaluate(progress);
            rectTransform.anchoredPosition = Vector2.LerpUnclamped(from, to, evaluate);
            yield return null;
        }

        rectTransform.anchoredPosition = to;
        onCompleted?.Invoke();
    }
    protected virtual Coroutine StartManagedTransition(object key, IEnumerator routine)
    {
        if (key == null || routine == null) return null;

        StopManagedTransition(key);
        Coroutine startedRoutine = StartCoroutine(WrapTransition(key, routine));
        activeTransitions[key] = startedRoutine;
        return startedRoutine;
    }

    protected virtual void StopManagedTransition(object key)
    {
        if (key == null) return;

        if (activeTransitions.TryGetValue(key, out Coroutine runningRoutine) && runningRoutine != null)
        {
            StopCoroutine(runningRoutine);
        }

        activeTransitions.Remove(key);
    }

    protected virtual IEnumerator WrapTransition(object key, IEnumerator routine)
    {
        yield return routine;

        if (key != null)
        {
            activeTransitions.Remove(key);
        }
    }
}
