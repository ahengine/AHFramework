using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using IEnumerator = System.Collections.IEnumerator;

namespace AHEFramework.UI
{
    public abstract class MonoBehaviourUIBase : MonoBehaviour
    {
        public static MonoBehaviourUIBase CurrentPage { private set; get; }
        public static MonoBehaviourUIBase ChangeCurrentPage
        {
            set
            {
                if (CurrentPage == value) return;

                if (CurrentPage) CurrentPage.Hide();
                CurrentPage = value;
                if (CurrentPage) CurrentPage.Show();
            }
        }
        public static MonoBehaviourUIBase ChangePageWithOutShow
        {
            set
            {
                if (CurrentPage) CurrentPage.Hide();
                CurrentPage = value;
                //if (CurrentPage) CurrentPage.Show();
            }
        }
        public virtual void ChangePage() => ChangeCurrentPage = this;


        [SerializeField] bool ShowAnimationOverlay = true;
        [SerializeField] protected Button backBtn;

        protected RectTransform rectTr;
        private Coroutine coroutineBase;

        [SerializeField] float animationDuration = .65f;
        [SerializeField] protected Animator animator;
        [SerializeField] protected OptionClass Option;

        public virtual bool haveBackground => true;

        public bool show { private set; get; }

        public virtual CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.Pages;

        protected void InitInstance()
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

        protected virtual void Init() 
        {
            backBtn?.onClick.AddListener(BackManager.Instance.ApplyBack);

            if (!animator && transform.childCount > 0)
                animator = transform.GetChild(0).GetComponent<Animator>();
        }

        public virtual void Show()
        {
            if (show) return;

            ShowForce();
        }
        public virtual void ShowForce()
        {
            show = true;

            Option.Apply();
            Option.BlackScreenChangeState = true;
            CanvasManager.Instance.BackgroundState = haveBackground;

            if (rectTr)
            {
                if (ShowAnimationOverlay) rectTr.SetAsLastSibling();
                else rectTr.SetAsFirstSibling();
            }

            if (coroutineBase != null) StopCoroutine(coroutineBase);
            coroutineBase = StartCoroutine(ShowCoroutine()); //print("Show: " + name);
        }
        private IEnumerator ShowCoroutine()
        {
            animator.gameObject.SetActive(true);
            animator.Play(AnimationStates.Show);

            yield return new WaitForSecondsRealtime(animationDuration);
            coroutineBase = null;
            ShowEndAnimation();
        }
        protected virtual void ShowEndAnimation() { }

        public virtual void Hide()
        {
            if (!show) return;

            show = false;

            Option.BlackScreenChangeState = false;
            //backBtn?.GetComponent<Animator>()?.Play(AnimationStates.Hide);

            if (coroutineBase != null) StopCoroutine(coroutineBase);
            coroutineBase = StartCoroutine(HideCoroutine());
        }
        private IEnumerator HideCoroutine()
        {
            animator.Play(AnimationStates.Hide);

            yield return new WaitForSecondsRealtime(animationDuration);

            animator.gameObject.SetActive(false);
            coroutineBase = null;
            HideEndAnimation();
        }
        protected virtual void HideEndAnimation() { }

        public void CreateInstance() { }
    }

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

    public abstract class PanelClass
    {
        [SerializeField] protected Animator _animator;
        public bool isShow { protected set; get; }

        public virtual void Show()
        {
            if (isShow) return;
            _animator.Play(AnimationStates.Show);
            isShow = true;
        }

        public virtual void Hide()
        {
            if (!isShow) return;
            _animator.Play(AnimationStates.Hide);
            isShow = false;
        }
    }
}