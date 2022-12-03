using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _brickcount;
    private int _ballcount;
    public float _startTime = 3;
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

    public GameState gameStates;
    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        // Make sure game state default state is preparation
        ChangeState(GameState.Start);
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    // increase number of bricks
    public void IncreaseBrickCount()
    {
        _brickcount++;
    }

    // decrease number of bricks
    public void DecreaseBrickCount()
    {
        _brickcount--;
    }

    public int GetBrickCount()
    {
        return _brickcount;
    }
    
    public int GetBallCount()
    {
        return _ballcount;
    }
    
    // increase number of bricks
    public void IncreaseBallCount()
    {
        _ballcount++;
    }

    // decrease number of bricks
    public void DecreaseBallCount()
    {
        _ballcount--;
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
                _inputManager.ToggleInputManager(true);
                break;
            case GameState.Wait:
                break;
            case GameState.Action:
                _inputManager.ToggleInputManager(false);
                break;
            case GameState.LevelVictory:
                break;
            case GameState.LevelDefeat:
                break;
            case GameState.GameVictory:
                break;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_startTime);
        ChangeState(GameState.Prep);
    }
    
}
