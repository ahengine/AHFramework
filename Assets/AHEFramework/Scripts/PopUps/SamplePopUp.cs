using UnityEngine;
using UnityEngine.UI;
using AHEFramework.UI;

namespace GameNameSpace.UI
{
    public class SamplePopUp : MonoBehaviourUI<SamplePopUp>
    {
        public override CanvasManager.RootsEnum rootType => CanvasManager.RootsEnum.PopUps;
    }
}
