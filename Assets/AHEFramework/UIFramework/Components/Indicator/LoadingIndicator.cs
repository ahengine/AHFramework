// Written by Hamidreza Karamain (AHEngine) - 2017
// Contact Me: ahengine@live.com

using UnityEngine;

namespace AHFramework.UIFramework.Components
{
    public class LoadingIndicator : MonoBehaviour
    {
        public UnityEngine.UI.Image maskImage;

        [SerializeField] Vector2 amountRange = new Vector2(.2f, .8f);
        [SerializeField] float amountSpeed = 2, rotateSpeed = 3;
        private float amountTarget;

        private Transform maskTr;
        private Vector3 localEulerAngles;

        private void Awake() => maskTr = maskImage.transform;

        private void OnEnable()
        {
            amountTarget = amountRange.x;
            maskImage.fillAmount = amountRange.y;
        }

        private void Update()
        {
            maskImage.fillAmount = Mathf.MoveTowards(maskImage.fillAmount, amountTarget, amountSpeed * Time.unscaledDeltaTime);

            if (maskImage.fillAmount == amountTarget)
            {
                if (amountTarget == amountRange.x)
                {
                    amountTarget = amountRange.y;
                    localEulerAngles.z += 360f * maskImage.fillAmount;
                    maskImage.fillClockwise = true;
                }
                else
                {
                    amountTarget = amountRange.x;
                    localEulerAngles.z -= 360f * maskImage.fillAmount;
                    maskImage.fillClockwise = false;
                }
            }

            localEulerAngles.z -= rotateSpeed * Time.deltaTime;
            maskTr.localEulerAngles = localEulerAngles;
        }
    }
}
