using UnityEngine;
using UnityEngine.UI;
using IEnumerator = System.Collections.IEnumerator;

namespace AHEFramework.UIFramework
{
    public abstract class MonoBehaviourUI<T> : MonoBehaviourUI where T : MonoBehaviourUI<T>
    {
        private static T _instance;
        public static T Instance => _instance ?? (_instance = GameObject.FindObjectOfType<T>());
    }

    public abstract class MonoBehaviourUI : MonoBehaviour
    {
        #region Change Page
        public static MonoBehaviourUI CurrentPage { private set; get; }
        public static MonoBehaviourUI ChangePageWithOutShow
        {
            set
            {
                if (CurrentPage) CurrentPage.Hide();
                CurrentPage = value;
            }
        }
        public static MonoBehaviourUI ChangeCurrentPage
        {
            set
            {
                if (CurrentPage == value) return;

                ChangePageWithOutShow = value;
                if (CurrentPage) CurrentPage.Show();
            }
        }

        public virtual void ChangePage() => ChangeCurrentPage = this;
        #endregion

        [SerializeField] bool ShowAnimationOverlay = true;
        [SerializeField] protected Button backBtn;

        protected RectTransform rectTr;
        private Coroutine coroutineBase;

        [SerializeField] float animationDuration = .65f;
        [SerializeField] protected Animator animator;

        public bool show { private set; get; }

        protected void Init()
        {
            backBtn?.onClick.AddListener(BackManager.Instance.ApplyBack);

            if (!animator && transform.childCount > 0)
                animator = transform.GetChild(0).GetComponent<Animator>();

            rectTr = GetComponent<RectTransform>();
        }

        protected virtual void Awake() => Init();

        public virtual void Show()
        {
            if (show) return;

            ShowForce();
        }
        public virtual void ShowForce()
        {
            show = true;

            if (rectTr)
            {
                if (ShowAnimationOverlay) rectTr.SetAsLastSibling();
                else rectTr.SetAsFirstSibling();
            }

            if (coroutineBase != null) StopCoroutine(coroutineBase);
            coroutineBase = StartCoroutine(ShowCoroutine());
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
}