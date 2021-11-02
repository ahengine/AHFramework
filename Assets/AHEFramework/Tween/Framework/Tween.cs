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

        #region MoveTowardsTo

        // Base
        public delegate bool MoveTowardsEndConditionAction();
        public Coroutine Towards(bool scaledTime, MoveTowardsEndConditionAction endConditionAction, UnityAction updateAction, UnityAction endAction) =>
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

        public Coroutine LerpTo(float duration, bool scaledTime, UnityAction<float> updateAction, UnityAction endAction) =>
            StartCoroutine(LerpToCoroutine(duration, scaledTime, updateAction, endAction));
        private IEnumerator LerpToCoroutine(float duration, bool scaledTime, UnityAction<float> updateAction, UnityAction endAction)
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
}
