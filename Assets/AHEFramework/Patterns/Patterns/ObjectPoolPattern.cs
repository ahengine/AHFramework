using System.Collections.Generic;
using UnityEngine;

namespace AHFramework.Pattern
{
    public abstract class ObjectPoolPattern<T> where T : MonoBehaviour
    {
        [SerializeField] T _prefab;
        private List<T> items = new List<T>();

        public T Get
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                    if (!items[i].gameObject.activeSelf)
                        return items[i];

                T newItem = GameObject.Instantiate(_prefab.gameObject).GetComponent<T>();
                items.Add(newItem);
                return newItem;
            }
        }
        public T GetActive
        {

            get
            {
                var item = Get;
                item.gameObject.SetActive(true);
                return item;
            }

        }


        public void Off()
        {
            for (int i = 0; i < items.Count; i++)
                if (!items[i].gameObject.activeSelf)
                    items[i].gameObject.SetActive(false);
        }
    }

    public abstract class ObjectPoolPatternMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] T _prefab;
        private List<T> items = new List<T>();

        public T Get
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                    if (!items[i].gameObject.activeSelf)
                        return items[i];

                T newItem = GameObject.Instantiate(_prefab.gameObject).GetComponent<T>();
                items.Add(newItem);
                return newItem;
            }
        }
        public T GetActive
        {

            get
            {
                var item = Get;
                item.gameObject.SetActive(true);
                return item;
            }

        }


        public void Off()
        {
            for (int i = 0; i < items.Count; i++)
                if (!items[i].gameObject.activeSelf)
                    items[i].gameObject.SetActive(false);
        }
    }

}