using UnityEngine;
using UnityEngine.Events;
using IEnumerator = System.Collections.IEnumerator;


namespace AHEFramework.GlobalCoroutine
{
    public class GlobalCoroutine : MonoBehaviour
    {
        public static bool CoroutineRunsBetweenScenes = false;

        private static GlobalCoroutine _instance;
        private static GlobalCoroutine Instance => _instance ? _instance : _instance = new GameObject("Global Coroutine").AddComponent<GlobalCoroutine>();

        public static Coroutine Run(IEnumerator coroutine) => Instance.StartCoroutine(coroutine);

        public static Coroutine InvokeAction(UnityAction action, float delay, bool scaledTime = true) => Instance.StartCoroutine(Instance.InvokeActionCoroutine(action, delay, scaledTime));
        private IEnumerator InvokeActionCoroutine(UnityAction action, float delay, bool scaledTime)
        {
            if (scaledTime) yield return new WaitForSeconds(delay);
            else yield return new WaitForSecondsRealtime(delay);

            action?.Invoke();
        }

        private void OnLevelWasLoaded(int level)
        {
            if (!CoroutineRunsBetweenScenes)
                StopAllCoroutines();
        }
    }
}