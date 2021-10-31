using AHEFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameNameSpace.UI
{
    public class SampleOverlayPage : MonoBehaviourUI<SampleOverlayPage>
    {
        public override CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.OverlayPages;

    }
}
