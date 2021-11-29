using System.Collections.Generic;
using UnityEngine;

namespace AHEFramework.Pattern
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
    public abstract class ObjectPoolPattern
    {
        [SerializeField] GameObject _prefab;
        private List<GameObject> items = new List<GameObject>();

        public GameObject Get
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                    if (!items[i].activeSelf)
                        return items[i];

                GameObject newItem = GameObject.Instantiate(_prefab).GetComponent<GameObject>();
                items.Add(newItem);
                return newItem;
            }
        }
        public GameObject GetActive
        {

            get
            {
                var item = Get;
                item.SetActive(true);
                return item;
            }

        }


        public void Off()
        {
            for (int i = 0; i < items.Count; i++)
                if (!items[i].activeSelf)
                    items[i].SetActive(false);
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public abstract class ObjectPoolPatternMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        [SerializeField] protected T _prefab;
        protected List<T> items = new List<T>();

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
    public abstract class ObjectPoolPatternMonoBehaviour : MonoBehaviour
    {
        [SerializeField] protected GameObject _prefab;
        protected List<GameObject> items = new List<GameObject>();

        public GameObject Get
        {
            get
            {
                for (int i = 0; i < items.Count; i++)
                    if (!items[i].activeSelf)
                        return items[i];

                GameObject newItem = GameObject.Instantiate(_prefab).GetComponent<GameObject>();
                items.Add(newItem);
                return newItem;
            }
        }
        public GameObject GetActive
        {

            get
            {
                var item = Get;
                item.SetActive(true);
                return item;
            }

        }

        public void Off()
        {
            for (int i = 0; i < items.Count; i++)
                if (!items[i].activeSelf)
                    items[i].SetActive(false);
        }
    }
}
