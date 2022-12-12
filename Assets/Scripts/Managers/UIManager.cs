using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject victoryPanelGo;
        public GameObject defeatPanelGo;
        public GameObject recallButton;
        public GameObject countdownPanelGo;
        private TextMeshProUGUI countdownText;
        private PoolManager _pm;
        private GameManager _gm;
        
        [Header("Initial")]
        public float startTime = 3f;
        private int _countDown;

        private void Awake()
        {
            
            _countDown = 3;
            countdownText = countdownPanelGo.GetComponentInChildren<TextMeshProUGUI>();
            countdownPanelGo.SetActive(true);
            
        }

        private void Start()
        {
            _gm = gameObject.GetComponent<GameManager>();
            _pm = gameObject.GetComponent<PoolManager>();
        }

        public void ToggleGoActive(GameObject gO,bool active)
        {
            gO.SetActive(active);
        }

        public IEnumerator CountDown()
        {
            while (_countDown > 0)
            {
                countdownText.text = _countDown.ToString();
                yield return new WaitForSeconds(startTime/3);
                _countDown--; 
            }
            ToggleGoActive(countdownPanelGo,false);
        }
    }
}
