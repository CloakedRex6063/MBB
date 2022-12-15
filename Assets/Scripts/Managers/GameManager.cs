using System.Collections;
using GameObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Rounds")] 
        public int maxRounds = 10;
        public int currentRounds;

        [Header("Game States")]
        public GameState gameStates;
    
        [Header("Manager")]
        private InputManager _inputManager;
        private UIManager _uiManager;
        private Cannon _cannon;

        public bool gameStarted;

        public enum GameState
        {
            Start,
            Prep,
            Wait,
            Action,
            LevelVictory,
            LevelDefeat,
            GameVictory
        }
        
        [Header("Brick Settings")]
        public int brickcount;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _uiManager = GetComponent<UIManager>();
            _cannon = FindObjectOfType<Cannon>();
            // Make sure game state default state is preparation
            ChangeState(GameState.Start);
            gameStarted = false;
        }

        private void Start()
        {
            StartCoroutine(StartTimer());
            _uiManager.ToggleGoActive(_uiManager.recallButton,false);
            Time.timeScale = 1f;
        }

        // increase number of bricks
        public void IncreaseBrickCount()
        {
            brickcount++;
        }

        // decrease number of bricks
        public void DecreaseBrickCount()
        {
            brickcount--;
        }

        public int GetBrickCount()
        {
            return brickcount;
        }
    
        public int GetBallCount()
        {
            return _cannon.GetBallCount();
        }
    
        public int GetRoundCount()
        {
            return maxRounds;
        }

        private void LevelWin()
        {
            if (gameStates != GameState.LevelDefeat && gameStates != GameState.LevelVictory)
            {
                if (brickcount < 1)
                {
                    StartCoroutine(Timer(GameState.LevelVictory));
                }

                if (brickcount > 0 && currentRounds > maxRounds)
                {
                    StartCoroutine(Timer(GameState.LevelDefeat));
                }
            }
        }

        // increase number of bricks
        public void IncreaseRoundCount()
        {
            maxRounds++;
        }

        // decrease number of balls
        public void DecreaseRoundCount()
        {
            maxRounds--;
        }

        private void Update()
        {
            LevelWin();
        }

        public void ChangeState(GameState gameState)
        {
            gameStates = gameState;
            switch (gameStates)
            {
                case GameState.Start:
                    _inputManager.ToggleInputManager(false);
                    _uiManager.ToggleGoActive(_uiManager.victoryPanelGo,false);
                    break;
                case GameState.Prep:
                    currentRounds++;
                    _inputManager.ToggleInputManager(true);
                    _uiManager.ToggleGoActive(_uiManager.recallButton,false);
                    gameStarted = true;
                    break;
                case GameState.Wait:
                    _inputManager.ToggleInputManager(false);
                    break;
                case GameState.Action:
                    _uiManager.ToggleGoActive(_uiManager.recallButton,true);
                    gameStarted = false;
                    break;
                case GameState.LevelVictory:
                    _inputManager.ToggleInputManager(false);
                    if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings - 1)
                    {
                        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1, LoadSceneMode.Single);
                    }
                    else
                    {
                        if (!_uiManager.victoryPanelGo.activeInHierarchy)
                        {
                            _uiManager.ToggleGoActive(_uiManager.victoryPanelGo,true);
                        }
                    }
                    break;
                case GameState.LevelDefeat:
                    _inputManager.ToggleInputManager(false);
                    _uiManager.ToggleGoActive(_uiManager.defeatPanelGo,true);
                    break;
                case GameState.GameVictory:
                    break;
            }
        }

        IEnumerator StartTimer()
        {
            StartCoroutine(_uiManager.CountDown());
            yield return new WaitForSeconds(_uiManager.startTime);
            ChangeState(GameState.Prep);
        }
        IEnumerator Timer(GameState state)
        {
            Time.timeScale = 0.25f;
            yield return new WaitForSeconds(1);
            ChangeState(state);
        }
    }
}
