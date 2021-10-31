using UnityEngine;
using UnityEngine.UI;

namespace AHEFramework.UI
{
    public class CanvasManager : MonoBehaviour
    {
        private const string PrefabAddress = "UI/Pages/Canvas";
        private const string PrefabLandscapeAddress = "UI/Pages/CanvasLandscape";

        private static CanvasManager instance;
        public static CanvasManager Instance { get { if (!instance) instance = Instantiate(Resources.Load<GameObject>(PrefabAddress)).GetComponent<CanvasManager>(); return instance; } }

        public enum RootsEnum { Background, Pages, OverlayPages, PopUps, OverlayPopUps, Landscape }

        [SerializeField] RectTransform backgroundRoot; private Animator backgroundRootAnimator; private bool backgroundState = true;
        [SerializeField] RectTransform pagesRoot;
        [SerializeField] RectTransform overlayPagesRoot;
        [SerializeField] RectTransform popupsRoot;
        [SerializeField] RectTransform overlayPopUpsRoot;
        private RectTransform landscapeCanvasRoot;
        private RectTransform landscapePagesRoot;
        private AudioListener audioListener;
        //[SerializeField] Button _splashBtn;

        public RectTransform GetRoot(RootsEnum type)
        {
            switch (type)
            {
                case RootsEnum.Background: return backgroundRoot;
                default: case RootsEnum.Pages: return pagesRoot;
                case RootsEnum.OverlayPages: return overlayPagesRoot;
                case RootsEnum.PopUps: return popupsRoot;
                case RootsEnum.OverlayPopUps: return overlayPopUpsRoot;
                case RootsEnum.Landscape: return landscapePagesRoot;
            }
        }

        private void Awake()
        {
            backgroundRootAnimator = backgroundRoot.GetComponent<Animator>();
            audioListener = GetComponent<AudioListener>(); //print("audioListener: " + audioListener.name);
            // landscapeCanvasRoot = Instantiate(Resources.Load<GameObject>(PrefabLandscapeAddress)).GetComponent<RectTransform>();
            //  landscapePagesRoot = landscapeCanvasRoot.GetChild(0).GetComponent<RectTransform>();
            //_splashBtn.onClick.AddListener(() => SplashPage.Instance.ChangePage());
        }

        public void TurnOnAudioListener(bool value) => audioListener.enabled = value;

        public bool BackgroundState
        {
            set
            {
                if (backgroundState == value) return;

                backgroundState = value;

                if (backgroundRootAnimator)
                    backgroundRootAnimator.Play(value ? AnimationStates.Show : AnimationStates.Hide);
                else backgroundRoot.gameObject.SetActive(value);
            }
        }

        public void CreateEmpty() { }
    }
}
