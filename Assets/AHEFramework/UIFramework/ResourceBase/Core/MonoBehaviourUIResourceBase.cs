using UnityEngine;
using UnityEngine.UI;

namespace AHEFramework.UIFramework
{
    public abstract class MonoBehaviourUIResourceBase<T> : MonoBehaviourUI where T : MonoBehaviourUIResourceBase<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    if (!(_instance = GameObject.FindObjectOfType<T>()))
                    {
                        _instance = Instantiate(Resources.Load<GameObject>(ConfigPages.GetPathByType(typeof(T)))).GetComponent<T>();
                        _instance.InitInstance();
                    }
                }

                return _instance;
            }
        }

        public virtual CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.Pages;
        public virtual bool haveBackground => true;
        [SerializeField] protected OptionClass Option;

        [System.Serializable]
        public class OptionClass
        {
            [SerializeField] Image blackScreenImg;
            public bool BlackScreenChangeState
            {
                set
                {
                    if (!blackScreenImg) return;

                    if (value) Config.Instance.BlackScreenHelper.Show(blackScreenImg);
                    else Config.Instance.BlackScreenHelper.Hide(blackScreenImg);
                }
            }

            public void Apply() { }
        }

        private void InitInstance()
        {
            RectTransform parent = CanvasManager.Instance.GetRoot(rootType);
            rectTr = GetComponent<RectTransform>();
            if (parent)
            {
                rectTr.SetParent(parent);
                rectTr.localScale = Vector2.one;
                rectTr.localPosition = Vector3.zero;
                rectTr.anchorMin = parent.anchorMin;
                rectTr.anchorMax = parent.anchorMax;
                rectTr.anchoredPosition = parent.anchoredPosition;
                rectTr.sizeDelta = parent.sizeDelta;
            }

            Init();
        }

        public override void ShowForce()
        {
            base.ShowForce();

            Option.Apply();
            Option.BlackScreenChangeState = true;

            CanvasManager.Instance.BackgroundState = haveBackground;
        }

        public override void Hide()
        {
            base.Hide();

            Option.BlackScreenChangeState = false;
        }
    }


}