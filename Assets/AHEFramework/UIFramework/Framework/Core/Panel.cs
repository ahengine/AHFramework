using System.Collections;
using UnityEngine;

namespace AHEFramework.UIFramework
{
    public abstract class Panel
    {
        private Coroutine _coroutineBase;

        [SerializeField] float animationDuration = .65f;
        [SerializeField] protected Animator animator;

        public bool show { private set; get; }

        public virtual void Show()
        {
            if (show) return;

            ShowForce();
        }
        public virtual void ShowForce()
        {
            show = true;

            if (_coroutineBase != null) GlobalCoroutine.Stop(_coroutineBase);
            _coroutineBase = GlobalCoroutine.Run(ShowCoroutine());
        }
        private IEnumerator ShowCoroutine()
        {
            animator.gameObject.SetActive(true);
            animator.Play(AnimationStates.Show);

            yield return new WaitForSecondsRealtime(animationDuration);
            _coroutineBase = null;
            ShowEndAnimation();
        }
        protected virtual void ShowEndAnimation() { }

        public virtual void Hide()
        {
            if (!show) return;

            show = false;

            if (_coroutineBase != null) GlobalCoroutine.Stop(_coroutineBase);
            _coroutineBase = GlobalCoroutine.Run(HideCoroutine());
        }
        private IEnumerator HideCoroutine()
        {
            animator.Play(AnimationStates.Hide);

            yield return new WaitForSecondsRealtime(animationDuration);

            animator.gameObject.SetActive(false);
            _coroutineBase = null;
            HideEndAnimation();
        }
        protected virtual void HideEndAnimation() { }

        public void CreateInstance() { }
    }
}