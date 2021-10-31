using AHEFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameNameSpace.UI
{
    public class SamplePage : MonoBehaviourUI<SamplePage>
    {
        [SerializeField] Button openPopUpBtn;

        protected override void Awake()
        {
            base.Awake();

            openPopUpBtn.onClick.AddListener(OpenPopUp);
        }

        private void OpenPopUp()
        {
            BackManager.Instance.AddBack = SamplePopUp.Instance.Hide;
            SamplePopUp.Instance.Show();
        }
    }
}
