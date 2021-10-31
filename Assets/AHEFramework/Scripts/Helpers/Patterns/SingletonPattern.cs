using UnityEngine;

namespace AHFramework.Pattern
{
    public abstract class SingletonPattern<T> where T : class, new()
    {
        private static T _instance;
        public static T Instance => _instance != null ? _instance : InitializeInstance();

        private static T InitializeInstance() => new T();
    }

    public abstract class SingletonPatternMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance => _instance ? _instance : InitializeInstance();

        private static T InitializeInstance()
        {
            _instance = GameObject.FindObjectOfType<T>();

            if (!_instance)
                _instance = new GameObject(typeof(T).Name).AddComponent<T>();

            return _instance;
        }
    }

}