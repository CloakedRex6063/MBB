using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject victoryPanelGo;
        public GameObject defeatPanelGo;
        public GameObject recallButton;

        public void ToggleGoActive(GameObject gO,bool active)
        {
            gO.SetActive(active);
        }
    }
}
