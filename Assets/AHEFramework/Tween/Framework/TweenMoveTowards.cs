using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AHEFramework.Tween
{
    public static class TweenMoveTowards
    {
         // Transform
    public static Coroutine MoveTowards(Transform tr, Vector3 target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ?Tween.Instance.Towards(scaledTime,()=> Vector3.Distance(tr.position, target) == 0,
            ()=> tr.position = Vector3.MoveTowards(tr.position, target, speed * (scaledTime?Time.deltaTime:Time.unscaledDeltaTime)),
            () => { tr.position = target; endAction?.Invoke(); })
        // Local Space
        : Tween.Instance.Towards(scaledTime, () => Vector3.Distance(tr.localPosition, target) == 0,
            () => tr.localPosition = Vector3.MoveTowards(tr.localPosition, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localPosition = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Quaternion target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Tween.Instance.Towards(scaledTime, () => Quaternion.Angle(tr.rotation, target) == 0,
            () => tr.rotation = Quaternion.RotateTowards(tr.rotation, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.rotation = target; endAction?.Invoke(); })
        // Local Space
        : Tween.Instance.Towards(scaledTime, () => Quaternion.Angle(tr.localRotation, target) == 0,
            () => tr.localRotation = Quaternion.RotateTowards(tr.localRotation, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localRotation = target; endAction?.Invoke(); });
    public static Coroutine RotateTowards(Transform tr, Vector3 target, float speed = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        worldSpace ? Tween.Instance.Towards(scaledTime, () => Vector3.Distance(tr.eulerAngles, target) == 0,
            () => tr.eulerAngles = Vector3.MoveTowards(tr.eulerAngles, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.eulerAngles = target; endAction?.Invoke(); })
        // Local Space
        : Tween.Instance.Towards(scaledTime, () => Vector3.Distance(tr.localEulerAngles, target) == 0,
            () => tr.localEulerAngles = Vector3.MoveTowards(tr.localEulerAngles, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localEulerAngles = target; endAction?.Invoke(); });
    public static Coroutine ScaleTowards(Transform tr, Vector3 target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
        // World Space
        Tween.Instance.Towards(scaledTime, () => Vector3.Distance(tr.localScale, target) == 0,
            () => tr.localScale = Vector3.MoveTowards(tr.localScale, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { tr.localScale = target; endAction?.Invoke(); });
    
    // UI
    public static Coroutine ImageFillAmountTowards(Image img, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
        Tween.Instance.Towards(scaledTime, () => Mathf.Abs(img.fillAmount - target) == 0,
            () => img.fillAmount = Mathf.MoveTowards(img.fillAmount, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
            () => { img.fillAmount = target; endAction?.Invoke(); });
    public static Coroutine SliderValueTowards(Slider slider, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Tween.Instance.Towards(scaledTime, () => Mathf.Abs(slider.value - target) == 0,
        () => slider.value = Mathf.MoveTowards(slider.value, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
        () => { slider.value = target; endAction?.Invoke(); });
    
    // Camera
    public static Coroutine FOVTowards(Camera cam, float target, float speed = 2, bool scaledTime = true, UnityAction endAction = null) =>
    Tween.Instance.Towards(scaledTime, () => Mathf.Abs(cam.fieldOfView - target) == 0,
        () => cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, speed * (scaledTime ? Time.deltaTime : Time.unscaledDeltaTime)),
        () => { cam.fieldOfView = target; endAction?.Invoke(); });
    }
}
