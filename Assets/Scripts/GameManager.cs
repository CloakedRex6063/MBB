using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _brickcount;

    public enum GameState
    {
        Prep,
        Wait,
        Action,
        LevelVictory,
        LevelDefeat,
        GameVictory
    }

    public GameState gameStates;
    private InputManager _inputManager;

    private void Awake()
    {
        // Make sure game state default state is preparation
        gameStates = GameState.Prep;
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        switch (gameStates)
        {
            case GameState.Prep:
                if (!_inputManager.enabled)
                {
                    _inputManager.enabled = true;
                }
                break;
            case GameState.Wait:
                break;
            case GameState.Action:
                if (_inputManager.enabled)
                {
                    _inputManager.enabled = false;
                }
                break;
            case GameState.LevelVictory:
                break;
            case GameState.LevelDefeat:
                break;
            case GameState.GameVictory:
                break;
            default:
                break;
        }
    }

    // increase number of bricks
    public void IncreaseBrickCount()
    {
        
    }

    // decrease number of bricks
    public void DecreaseBrickCount()
    {
        
    }

    public void ChangeState(GameState gameState)
    {
        gameStates = gameState;
    }
}
