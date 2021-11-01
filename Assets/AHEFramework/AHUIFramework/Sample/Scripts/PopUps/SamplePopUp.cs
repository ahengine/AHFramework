using UnityEngine;
using UnityEngine.UI;
using AHEFramework.UIFramework;

namespace GameNameSpace.UI
{
    public class SamplePopUp : MonoBehaviourUI<SamplePopUp>
    {
        public override CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.PopUps;
    }
}
