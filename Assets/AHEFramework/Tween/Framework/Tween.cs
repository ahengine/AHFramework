using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AHEFramework.Tween
{
    public class Tween : MonoBehaviour
    {
        public static Tween Instance { get { if (!m_instance) InitInstance(); return m_instance; } }
        private static Tween m_instance;

        private static void InitInstance() =>
            m_instance = new GameObject("TweenHelper").AddComponent<Tween>();

        public static void StopAllTween() => Instance.StopAllCoroutines();

        public static Coroutine StopTween { set { if (value != null) { Instance.StopCoroutine(value); value = null; } } }

        public Coroutine DoTween(float duration, bool scaledTime, UnityAction<float> updateAction, UnityAction endAction) =>
            StartCoroutine(TweenCoroutine(duration, scaledTime, updateAction, endAction));
        private IEnumerator TweenCoroutine(float duration, bool scaledTime, UnityAction<float> updateAction, UnityAction endAction)
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
    }
}
