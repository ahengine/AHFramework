using UnityEngine;
using UnityEngine.Events;
using UnityWebRequest = UnityEngine.Networking.UnityWebRequest;
using System.Collections;

namespace FootballManager.Providers
{
    public static class InternetProvider
    {
        public static void ActionWithInternetCheck(UnityAction<bool> action) =>
            AHEFramework.GlobalCoroutine.Run(CheckInternetConnection(action));

        // For Internet Check
        private static IEnumerator CheckInternetConnection(UnityAction<bool> action)
        {
            UnityWebRequest request = new UnityWebRequest("http://google.com");
            yield return request.SendWebRequest();
            if (request.error != null) // Internet Error
            {
                Debug.LogError("CheckInternetConnection ERROR: "+request.error);
                // Show Internet have problem message
                action(false);
            }
            else
            {
                action(true);
            }
        }
    }
}