// Written by Hamidreza Karamain (AHEngine) - 2017
// Contact Me: ahengine@live.com

using UnityEngine;

namespace AHFramework.UIFramework.Components
{
    public class LoadingIndicator : MonoBehaviour
    {
        public UnityEngine.UI.Image maskImage;

        [SerializeField] Vector2 amountRange = new Vector2(.2f, .8f);
        private float amountTarget;
        [SerializeField] float amountSpeed = 2;
        [SerializeField] float rotateSpeed = 3;

        private Transform maskTr;
        private Vector3 rotation;

        private void Awake()
        {
            maskTr = maskImage.transform;
        }

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
                    rotation.z += 360f * maskImage.fillAmount;
                    maskImage.fillClockwise = true;
                }
                else
                {
                    amountTarget = amountRange.x;
                    rotation.z -= 360f * maskImage.fillAmount;
                    maskImage.fillClockwise = false;
                }
            }

            rotation.z -= rotateSpeed * Time.deltaTime;
            maskTr.localEulerAngles = rotation;
        }
    }
}
