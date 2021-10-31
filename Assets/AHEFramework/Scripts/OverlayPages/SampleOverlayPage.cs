using AHEFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameNameSpace.UI
{
    public class SampleOverlayPopUp : MonoBehaviourUI<SampleOverlayPopUp>
    {
        public override CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.OverlayPopUps;

    }
}
