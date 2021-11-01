using UnityEngine;
using UnityEngine.UI;


namespace AHEFramework.UIFramework
{
    [CreateAssetMenu(fileName ="Config",menuName = "AHEUIFramework/ New Config",order = 51)]
    public class Config : ScriptableObject
    {
        private const string FileAddress = "Config";

        private static Config m_instance;
        public static Config Instance => m_instance ? m_instance : m_instance = Resources.Load<Config>(FileAddress);

        [System.Serializable]
        public class BlackScreenClass
        {
            [SerializeField] float changeDuration = .1f;
            [SerializeField,Range(0.5f,1)] float value = .75f;

            public void Show(Image img) => Tween.ImageAlphaLerp(img, value, changeDuration, false);
            public void Hide(Image img) => Tween.ImageAlphaLerp(img, 0, changeDuration, false);
        }
        public BlackScreenClass BlackScreenHelper;
    }

    public static class AnimationStates
    {
        public const string Show = "Show",
                            Hide = "Hide";
    }
}