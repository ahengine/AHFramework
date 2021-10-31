using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using AHEFramework.UI;


namespace GameNameSpace.UI
{
    public class PopUp : MonoBehaviourUI<PopUp>
    {
        public const string PageAddress = "PopUp";

        [Separator("Ref")]
        [SerializeField] Text messageTxt;
        [SerializeField] Button okBtn; private Text okBtnTxt; private string okLabel;
        [SerializeField] GameObject answerBtnsRoot;
        [SerializeField] Button yesBtn; private Text yesBtnTxt; private string yesLabel;
        [SerializeField] Button noBtn; private Text noBtnTxt; private string noLabel;

        private UnityAction okAction;
        private UnityAction<bool> answerAction;

        protected override void Awake()
        {
            base.Awake();

            okBtn.onClick.AddListener(Ok); okLabel = (okBtnTxt = okBtn.GetComponentInChildren<Text>()).text;
            noBtn.onClick.AddListener(() => Answer(false)); noLabel = (noBtnTxt = noBtn.GetComponentInChildren<Text>()).text;
            yesBtn.onClick.AddListener(() => Answer(true)); yesLabel = (yesBtnTxt = yesBtn.GetComponentInChildren<Text>()).text;
        }

        public override void Show()
        {
            base.Show();
            yesBtn.interactable = noBtn.interactable = okBtn.interactable = false;
            SetOption();
        }
        protected override void ShowEndAnimation()
        {
            base.ShowEndAnimation();
            yesBtn.interactable = noBtn.interactable = okBtn.interactable = true;
        }

        [System.Serializable]
        public class MessageOptionClass
        {
            public string okLabelBtn;
            public string yesLabelBtn;
            public string noLabelBtn;
        }

        public void Show(string message, UnityAction action = null)
        {
            #region Base
            Show();

            answerBtnsRoot.SetActive(false);
            okBtn.gameObject.SetActive(true);
            #endregion

            messageTxt.text = message;
            okAction = action;
        }
        public void Show(string message, UnityAction yesAction, UnityAction noAction)
        {
            #region Base
            Show();

            answerBtnsRoot.SetActive(true);
            okBtn.gameObject.SetActive(false);
            #endregion

            messageTxt.text = message;
            answerAction = (answer) => { if (answer) yesAction(); else noAction(); };
        }
        public void Show(string message, UnityAction<bool> action)
        {
            #region Base
            Show();

            answerBtnsRoot.SetActive(true);
            okBtn.gameObject.SetActive(false);
            #endregion

            messageTxt.text = message;
            answerAction = action;
        }

        public void SetOption(MessageOptionClass options = null)
        {
            if (options == null)
            {
                okBtnTxt.text = okLabel;
                yesBtnTxt.text = yesLabel;
                noBtnTxt.text = noLabel;

                return;
            }


            if (string.IsNullOrEmpty(options.okLabelBtn)) options.okLabelBtn = okLabel;
            if (string.IsNullOrEmpty(options.yesLabelBtn)) options.yesLabelBtn = yesLabel;
            if (string.IsNullOrEmpty(options.noLabelBtn)) options.noLabelBtn = noLabel;

            okBtnTxt.text = options.okLabelBtn;
            yesBtnTxt.text = options.yesLabelBtn;
            noBtnTxt.text = options.noLabelBtn;
        }

        private void Answer(bool yes)
        {
            if (answerAction != null) { answerAction(yes); answerAction = null; }
            Hide();
        }
        private void Ok()
        {
            if (okAction != null) { okAction(); okAction = null; }
            Hide();
        }
    }
}