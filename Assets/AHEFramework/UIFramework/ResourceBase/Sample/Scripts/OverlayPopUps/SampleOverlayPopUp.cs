using AHEFramework.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace GameNameSpace.UI
{
    public class SampleOverlayPage : MonoBehaviourUIResourceBase<SampleOverlayPage>
    {
        public override CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.OverlayPages;

    }
}
