using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AHEFramework.Tween
{
    public static class TweenMoveTowards
    {
        // Transform
        public static Coroutine MoveTowards(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
            // World Space
            worldSpace ? Tween.Instance.DoTween(duration, scaledTime,
                (time) => tr.position = Vector3.MoveTowards(tr.position, target, time),
                () => { tr.position = target; endAction?.Invoke(); })
            // Local Space
            : Tween.Instance.DoTween(duration, scaledTime,
                (time) => tr.localPosition = Vector3.MoveTowards(tr.localPosition, target, time),
                () => { tr.localPosition = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Quaternion target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Tween.Instance.DoTween(duration,scaledTime,
            (time) => tr.rotation = Quaternion.RotateTowards(tr.rotation, target, time),
            () => { tr.rotation = target; endAction?.Invoke(); })
        // Local Space
        : Tween.Instance.DoTween(duration,scaledTime,
            (time) => tr.localRotation = Quaternion.RotateTowards(tr.localRotation, target, time),
            () => { tr.localRotation = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Tween.Instance.DoTween(duration,scaledTime,
            (time) => tr.eulerAngles = Vector3.MoveTowards(tr.eulerAngles, target,time),
            () => { tr.eulerAngles = target; endAction?.Invoke(); })
        // Local Space
        : Tween.Instance.DoTween(duration,scaledTime,
            (time) => tr.localEulerAngles = Vector3.MoveTowards(tr.localEulerAngles, target, time),
            () => { tr.localEulerAngles = target; endAction?.Invoke(); });
    public static Coroutine ScaleTowards(Transform tr, Vector3 target, float duration = 2, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        Tween.Instance.DoTween(duration,scaledTime,
            (time) => tr.localScale = Vector3.MoveTowards(tr.localScale, target, time),
            () => { tr.localScale = target; endAction?.Invoke(); });
    
    // UI
    public static Coroutine ImageFillAmountTowards(Image img, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null) =>
        Tween.Instance.DoTween(duration,scaledTime,
            (time) => img.fillAmount = Mathf.MoveTowards(img.fillAmount, target, time),
            () => { img.fillAmount = target; endAction?.Invoke(); });
    public static Coroutine SliderValueTowards(Slider slider, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Tween.Instance.DoTween(duration,scaledTime,
        (time) => slider.value = Mathf.MoveTowards(slider.value, target, time),
        () => { slider.value = target; endAction?.Invoke(); });
    
    // Camera
    public static Coroutine FOVTowards(Camera cam, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Tween.Instance.DoTween(duration,scaledTime,
        (time) => cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, time),
        () => { cam.fieldOfView = target; endAction?.Invoke(); });
    }
}
