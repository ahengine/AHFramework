using UnityEngine;
using UnityEngine.UI;

namespace AHEFramework.UIFramework
{
    public abstract class MonoBehaviourUI<T> : MonoBehaviourUIBase where T : MonoBehaviourUI<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    if (!(instance = GameObject.FindObjectOfType<T>()))
                    {
                        instance = Instantiate(Resources.Load<GameObject>(ConfigPages.GetPathByType(typeof(T)))).GetComponent<T>();
                        instance.InitInstance();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake() => instance = this as T;
    }
}