using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tween : MonoBehaviour
{
    private static Tween Instance { get { if (!m_instance) InitInstance(); return m_instance; } }
    private static Tween m_instance;

    private static void InitInstance() =>
        m_instance = new GameObject("TweenHelper").AddComponent<Tween>();

    public static void StopAllTween() => Instance.StopAllCoroutines();

    public static Coroutine StopTween { set { if (value != null) { Instance.StopCoroutine(value); value = null; } } }

    #region MoveTowardsTo
    // Transform
    public static Coroutine MoveTowards(Transform tr, Vector3 target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ?Instance.Towards(scaledTime,()=> Vector3.Distance(tr.position, target) == 0,
            ()=> tr.position = Vector3.MoveTowards(tr.position, target, speed * (scaledTime?Time.deltaTime:Time.unscaledDeltaTime)),
            () => { tr.position = target; endAction?.Invoke(); })
        // Local Space
        : Instance.Towards(scaledTime, () => Vector3.Distance(tr.localPosition, target) == 0,
            () => tr.localPosition = Vector3.MoveTowards(tr.localPosition, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localPosition = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Quaternion target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Instance.Towards(scaledTime, () => Quaternion.Angle(tr.rotation, target) == 0,
            () => tr.rotation = Quaternion.RotateTowards(tr.rotation, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.rotation = target; endAction?.Invoke(); })
        // Local Space
        : Instance.Towards(scaledTime, () => Quaternion.Angle(tr.localRotation, target) == 0,
            () => tr.localRotation = Quaternion.RotateTowards(tr.localRotation, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localRotation = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Vector3 target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Instance.Towards(scaledTime, () => Vector3.Distance(tr.eulerAngles, target) == 0,
            () => tr.eulerAngles = Vector3.MoveTowards(tr.eulerAngles, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.eulerAngles = target; endAction?.Invoke(); })
        // Local Space
        : Instance.Towards(scaledTime, () => Vector3.Distance(tr.localEulerAngles, target) == 0,
            () => tr.localEulerAngles = Vector3.MoveTowards(tr.localEulerAngles, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localEulerAngles = target; endAction?.Invoke(); });
    public static Coroutine ScaleTowards(Transform tr, Vector3 target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        Instance.Towards(scaledTime, () => Vector3.Distance(tr.localScale, target) == 0,
            () => tr.localScale = Vector3.MoveTowards(tr.localScale, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localScale = target; endAction?.Invoke(); });
    
    // UI
    public static Coroutine ImageFillAmountTowards(Image img, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
        Instance.Towards(scaledTime, () => Mathf.Abs(img.fillAmount - target) == 0,
            () => img.fillAmount = Mathf.MoveTowards(img.fillAmount, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { img.fillAmount = target; endAction?.Invoke(); });
    public static Coroutine SliderValueTowards(Slider slider, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Instance.Towards(scaledTime, () => Mathf.Abs(slider.value - target) == 0,
        () => slider.value = Mathf.MoveTowards(slider.value, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
        () => { slider.value = target; endAction?.Invoke(); });
    
    // Camera
    public static Coroutine FOVTowards(Camera cam, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Instance.Towards(scaledTime, () => Mathf.Abs(cam.fieldOfView - target) == 0,
        () => cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
        () => { cam.fieldOfView = target; endAction?.Invoke(); });

    // Base
    public delegate bool MoveTowardsEndConditionAction();
    private Coroutine Towards(bool scaledTime, MoveTowardsEndConditionAction endConditionAction, UnityAction updateAction, UnityAction endAction) =>
        StartCoroutine(TowardsCoroutine(scaledTime, endConditionAction, updateAction, endAction));
    private IEnumerator TowardsCoroutine(bool scaledTime, MoveTowardsEndConditionAction endConditionAction, UnityAction updateAction, UnityAction endAction)
    {
        float timer = 0;
        while (true)
        {
            timer += scaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
            updateAction?.Invoke();
            yield return new WaitForEndOfFrame();

            if (endConditionAction())
            {
                endAction?.Invoke();
                break;
            }
        }
    }
    #endregion

    #region LerpTo

    // Transform
    public static Coroutine MoveLerp(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
    {
        Vector3 startValue = Vector3.zero;
        if (worldSpace)
        {
            startValue = tr.position;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.position = Vector3.Lerp(startValue, target, value), () => { tr.position = target; endAction?.Invoke(); });
        }
        else
        {
            startValue = tr.localPosition;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.localPosition = Vector3.Lerp(startValue, target, value), () => { tr.localPosition = target; endAction?.Invoke();});
    }
    }
    public static Coroutine RotateQuaternionLerp(Transform tr, Quaternion target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
    {
        Quaternion startValue = Quaternion.identity;
        if (worldSpace)
        {
            startValue = tr.rotation;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.rotation = Quaternion.Lerp(startValue, target, value), () => { tr.rotation = target; endAction?.Invoke(); });
    }
        else
        {
            startValue = tr.localRotation;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.localRotation = Quaternion.Lerp(startValue, target, value), () => { tr.localRotation = target; endAction?.Invoke(); });
        }
    }
    public static Coroutine RotateEulerLerp(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
    {
        Vector3 startValue = Vector3.zero;
        if (worldSpace)
        {
            startValue = tr.eulerAngles;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.eulerAngles = Vector3.Lerp(startValue, target, value), () => { tr.eulerAngles = target; endAction?.Invoke(); });
        }
        else
        {
            startValue = tr.localEulerAngles;
            return Instance.LerpTo(duration, scaledTime, (value) => tr.localEulerAngles = Vector3.Lerp(startValue, target, value), () => { tr.localEulerAngles = target; endAction?.Invoke(); });
        }
    }
    public static Coroutine ScaleLerp(Transform tr, Vector3 target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Vector3 startValue = tr.localScale;
        return Instance.LerpTo(duration, scaledTime, (value) => tr.localScale = Vector3.Lerp(startValue, target, value), () => { tr.localScale = target; endAction?.Invoke(); });
    }
    
    // Color
    public static Coroutine ImageColorLerp(Image img, Color target, float duration, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = img.color;
        return Instance.LerpTo(duration, scaledTime, (value) => img.color = Color.Lerp(startValue, target, value), () => { img.color = target; endAction?.Invoke(); });
    }
    public static Coroutine TextColorLerpTo(Text txt, Color target, float duration, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = txt.color;
        return Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, target, value), () => { txt.color = target; endAction?.Invoke(); });
    }
    public static Coroutine SpriteRendererColorLerp(SpriteRenderer sr, Color target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = sr.color;
        return Instance.LerpTo(duration, scaledTime, (value) => sr.color = Color.Lerp(startValue, target, value), () => { sr.color = target; endAction?.Invoke(); });
    }
   
    // Alpha
    public static Coroutine ImageAlphaLerp(Image img, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = img.color;
        Color targetValue = startValue; targetValue.a = target;
        return Instance.LerpTo(duration, scaledTime, (value) => img.color = Color.Lerp(startValue, targetValue, value), () => { img.color = startValue; endAction?.Invoke(); });
    }
    public static Coroutine TextAlphaLerp(Text txt, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = txt.color;
        Color targetValue = startValue; targetValue.a = target;
        return Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, targetValue, value), () => { txt.color = startValue; endAction?.Invoke(); });
    }
    public static Coroutine TextMeshAlphaLerp(TextMesh txt, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = txt.color;
        Color targetValue = startValue; targetValue.a = target;
        return Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, targetValue, value), () => { txt.color = startValue; endAction?.Invoke(); });
    }
    public static Coroutine SpriteRendererAlphaLerp(SpriteRenderer sr, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        Color startValue = sr.color;
        Color targetValue = startValue; targetValue.a = target;
        return Instance.LerpTo(duration, scaledTime, (value) => sr.color = Color.Lerp(startValue, targetValue, value), () => { sr.color = startValue; endAction?.Invoke(); });
    }
    public static Coroutine CanvasGroupAlphaLerp(CanvasGroup canvasGroup, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        float startValue = canvasGroup.alpha;
        return Instance.LerpTo(duration, scaledTime, (value) => canvasGroup.alpha = Mathf.Lerp(startValue, target, value), () => { canvasGroup.alpha = target; endAction?.Invoke(); });
    }

    // Fill Amount
    public static Coroutine ImageFillAmountLerp(Image img, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        float startValue = img.fillAmount;
        return Instance.LerpTo(duration, scaledTime, (value) => img.fillAmount = Mathf.Lerp(startValue, target, value), () => { img.fillAmount = target; endAction?.Invoke(); });
    }

    // Camera
    public static Coroutine FOVLerp(Camera cam, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
    {
        float startValue = cam.fieldOfView;
        return Instance.LerpTo(duration, scaledTime, (value) => cam.fieldOfView = Mathf.Lerp(startValue, target, value), () => { cam.fieldOfView = target; endAction?.Invoke(); });
    }

    // Variables
    public static Coroutine FloatLerp(float current, float target, float duration, bool scaledTime = true, UnityAction<float> updateAction = null, UnityAction<float> endAction = null)
    {
        float startValue = current;
        return Instance.LerpTo(duration, scaledTime, (value) => { current = Mathf.Lerp(startValue, target, value); endAction?.Invoke(current); }, () => { current = target; endAction?.Invoke(current); });
    }

    // Base
    private Coroutine LerpTo(float duration, bool scaledTime, UnityAction<float> updateAction, UnityAction endAction) =>
        StartCoroutine(LerpToCoroutine(duration, scaledTime, updateAction, endAction));
    private IEnumerator LerpToCoroutine(float duration, bool scaledTime, UnityAction<float> updateAction,UnityAction endAction)
    {
        float timer = 0;
        while (true)
        {
            timer += scaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
            updateAction?.Invoke(timer / duration);
            yield return new WaitForEndOfFrame();

            if ((timer / duration) >= 1)
            {
                endAction?.Invoke();
                break;
            }
        }
    }
    #endregion
}
