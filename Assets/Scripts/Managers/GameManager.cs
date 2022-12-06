using System.Collections;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Rounds")] 
        public int maxRounds = 10;
        public int currentRounds;
    
        [Header("Initial")]
        public float startTime = 3f;

        [Header("Game States")]
        public GameState gameStates;
    
        [Header("Manager")]
        private InputManager _inputManager;
        private UIManager _uiManager;
        private Cannon _cannon;

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
        }

        private void Start()
        {
            StartCoroutine(StartTimer());
            _uiManager.ToggleGoActive(_uiManager.recallButton,false);
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

        void LevelWin()
        {
            if (gameStates != GameState.LevelVictory && gameStates != GameState.LevelDefeat)
            {
                if (brickcount == 0)
                { 
                    ChangeState(GameState.LevelVictory);
                }

                if (brickcount != 0 && currentRounds > maxRounds)
                {
                    ChangeState(GameState.LevelDefeat);
                }
            }
        }
    
        // increase number of bricks
        public void IncreaseBallCount()
        {
            _cannon.IncreaseBallCount();
        }

        // decrease number of balls
        public void DecreaseBallCount()
        {
            _cannon.DecreaseBallCount();
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
                    break;
                case GameState.Prep:
                    currentRounds++;
                    _inputManager.ToggleInputManager(true);
                    _uiManager.ToggleGoActive(_uiManager.recallButton,false);
                    break;
                case GameState.Wait:
                    _inputManager.ToggleInputManager(false);
                    break;
                case GameState.Action:
                    _uiManager.ToggleGoActive(_uiManager.recallButton,true);
                    break;
                case GameState.LevelVictory:
                    _inputManager.ToggleInputManager(false);
                    _uiManager.ToggleGoActive(_uiManager.victoryPanelGo,true);
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
            yield return new WaitForSeconds(startTime);
            ChangeState(GameState.Prep);
        }
    
    }
}
