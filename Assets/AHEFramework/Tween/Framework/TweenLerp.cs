using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AHEFramework.Tween
{
    public static class TweenLerp
    {
        // Transform
        public static Coroutine MoveLerp(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
        {
            Vector3 startValue = Vector3.zero;
            if (worldSpace)
            {
                startValue = tr.position;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.position = Vector3.Lerp(startValue, target, value), () => { tr.position = target; endAction?.Invoke(); });
            }
            else
            {
                startValue = tr.localPosition;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.localPosition = Vector3.Lerp(startValue, target, value), () => { tr.localPosition = target; endAction?.Invoke(); });
            }
        }
        public static Coroutine RotateQuaternionLerp(Transform tr, Quaternion target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
        {
            Quaternion startValue = Quaternion.identity;
            if (worldSpace)
            {
                startValue = tr.rotation;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.rotation = Quaternion.Lerp(startValue, target, value), () => { tr.rotation = target; endAction?.Invoke(); });
            }
            else
            {
                startValue = tr.localRotation;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.localRotation = Quaternion.Lerp(startValue, target, value), () => { tr.localRotation = target; endAction?.Invoke(); });
            }
        }
        public static Coroutine RotateEulerLerp(Transform tr, Vector3 target, float duration = 2, bool worldSpace = true, bool scaledTime = true, UnityAction endAction = null)
        {
            Vector3 startValue = Vector3.zero;
            if (worldSpace)
            {
                startValue = tr.eulerAngles;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.eulerAngles = Vector3.Lerp(startValue, target, value), () => { tr.eulerAngles = target; endAction?.Invoke(); });
            }
            else
            {
                startValue = tr.localEulerAngles;
                return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.localEulerAngles = Vector3.Lerp(startValue, target, value), () => { tr.localEulerAngles = target; endAction?.Invoke(); });
            }
        }
        public static Coroutine ScaleLerp(Transform tr, Vector3 target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Vector3 startValue = tr.localScale;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => tr.localScale = Vector3.Lerp(startValue, target, value), () => { tr.localScale = target; endAction?.Invoke(); });
        }

        // Color
        public static Coroutine ImageColorLerp(Image img, Color target, float duration, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = img.color;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => img.color = Color.Lerp(startValue, target, value), () => { img.color = target; endAction?.Invoke(); });
        }
        public static Coroutine TextColorLerpTo(Text txt, Color target, float duration, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = txt.color;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, target, value), () => { txt.color = target; endAction?.Invoke(); });
        }
        public static Coroutine SpriteRendererColorLerp(SpriteRenderer sr, Color target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = sr.color;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => sr.color = Color.Lerp(startValue, target, value), () => { sr.color = target; endAction?.Invoke(); });
        }

        // Alpha
        public static Coroutine ImageAlphaLerp(Image img, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = img.color;
            Color targetValue = startValue; targetValue.a = target;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => img.color = Color.Lerp(startValue, targetValue, value), () => { img.color = startValue; endAction?.Invoke(); });
        }
        public static Coroutine TextAlphaLerp(Text txt, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = txt.color;
            Color targetValue = startValue; targetValue.a = target;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, targetValue, value), () => { txt.color = startValue; endAction?.Invoke(); });
        }
        public static Coroutine TextMeshAlphaLerp(TextMesh txt, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = txt.color;
            Color targetValue = startValue; targetValue.a = target;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => txt.color = Color.Lerp(startValue, targetValue, value), () => { txt.color = startValue; endAction?.Invoke(); });
        }
        public static Coroutine SpriteRendererAlphaLerp(SpriteRenderer sr, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            Color startValue = sr.color;
            Color targetValue = startValue; targetValue.a = target;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => sr.color = Color.Lerp(startValue, targetValue, value), () => { sr.color = startValue; endAction?.Invoke(); });
        }
        public static Coroutine CanvasGroupAlphaLerp(CanvasGroup canvasGroup, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            float startValue = canvasGroup.alpha;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => canvasGroup.alpha = Mathf.Lerp(startValue, target, value), () => { canvasGroup.alpha = target; endAction?.Invoke(); });
        }

        // Fill Amount
        public static Coroutine ImageFillAmountLerp(Image img, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            float startValue = img.fillAmount;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => img.fillAmount = Mathf.Lerp(startValue, target, value), () => { img.fillAmount = target; endAction?.Invoke(); });
        }

        // Camera
        public static Coroutine FOVLerp(Camera cam, float target, float duration = 2, bool scaledTime = true, UnityAction endAction = null)
        {
            float startValue = cam.fieldOfView;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => cam.fieldOfView = Mathf.Lerp(startValue, target, value), () => { cam.fieldOfView = target; endAction?.Invoke(); });
        }

        // Variables
        public static Coroutine FloatLerp(float current, float target, float duration, bool scaledTime = true, UnityAction<float> updateAction = null, UnityAction<float> endAction = null)
        {
            float startValue = current;
            return Tween.Instance.LerpTo(duration, scaledTime, (value) => { current = Mathf.Lerp(startValue, target, value); endAction?.Invoke(current); }, () => { current = target; endAction?.Invoke(current); });
        }
    }
}
