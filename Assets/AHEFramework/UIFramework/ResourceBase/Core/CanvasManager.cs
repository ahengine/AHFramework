using UnityEngine;
using UnityEngine.UI;

namespace AHEFramework.UIFramework
{
    public sealed class CanvasManager : MonoBehaviour
    {
        private const string PrefabAddress = "UI/Pages/Canvas";

        private static CanvasManager instance;
        public static CanvasManager Instance { get { if (!instance) instance = Instantiate(Resources.Load<GameObject>(PrefabAddress)).GetComponent<CanvasManager>(); return instance; } }

        public enum RootsEnum { Background, Pages, OverlayPages, PopUps, OverlayPopUps }

        private Animator backgroundRootAnimator; 
        [SerializeField] RectTransform backgroundRoot,pagesRoot,overlayPagesRoot,popupsRoot,overlayPopUpsRoot;
        private AudioListener audioListener;

        public RectTransform GetRoot(RootsEnum type)
        {
            switch (type)
            {
                case RootsEnum.Background: return backgroundRoot;
                default: case RootsEnum.Pages: return pagesRoot;
                case RootsEnum.OverlayPages: return overlayPagesRoot;
                case RootsEnum.PopUps: return popupsRoot;
                case RootsEnum.OverlayPopUps: return overlayPopUpsRoot;
            }
        }

        private void Awake()
        {
            backgroundRootAnimator = backgroundRoot.GetComponent<Animator>();
            audioListener = GetComponent<AudioListener>();
        }

        public void TurnOnAudioListener(bool value) => audioListener.enabled = value;

        private bool _backgroundState = true;
        public bool BackgroundState
        {
            set
            {
                if (_backgroundState == value) return;

                _backgroundState = value;

                if (backgroundRootAnimator)
                    backgroundRootAnimator.Play(value ? AnimationStates.Show : AnimationStates.Hide);
                else backgroundRoot.gameObject.SetActive(value);
            }
        }

        public void CreateEmpty() { }
    }
}
