using UnityEngine;
using UnityAction = UnityEngine.Events.UnityAction;

using System.Collections.Generic;

namespace AHEFramework.UIFramework
{
    public sealed class BackManager : MonoBehaviour
    {
        private static BackManager instance;
        public static BackManager Instance { get { if (!instance) instance = new GameObject("BackManager").AddComponent<BackManager>(); return instance; } }

        private List<UnityAction> actions = new List<UnityAction>();

        public UnityAction SetAppExitPopUp;

        public bool HaveAction => actions.Count > 0;
        public int ActionCount => actions.Count;

        public bool AllowBack { get; private set; } = true;

        public void SetAllowBack(bool value) => AllowBack = value;

        public UnityAction AddBack { set => actions.Add(value); } 
        public void RemoveAllBacks() => actions.Clear();

        public void RemoveLastBack()
        {
            if (actions.Count > 0)
                actions.RemoveAt(actions.Count - 1);
        }
        public UnityAction ReplaceLastBack
        {
            set
            {
                RemoveLastBack();
                AddBack = value;
            }
        }

        public void ApplyBack()
        {
            if (actions.Count == 0)
            {
                SetAppExitPopUp?.Invoke();

                return;
            }

            if (actions[actions.Count - 1] != null)
                actions[actions.Count - 1]();

            actions.RemoveAt(actions.Count - 1);
        }


        public void ApplyBackByIndex(int index)
        {
            if (actions.Count <= index || index < 0)
                return;

            if (actions[index] != null)
                actions[index]();

            if (actions.Count > index)
                actions.RemoveAt(index);

        }


        public void ApplyBackAll()
        {
            if (actions.Count == 0) return;

            while (actions.Count > 0)
                ApplyBack();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && AllowBack)
                ApplyBack();
        }
    }
}
