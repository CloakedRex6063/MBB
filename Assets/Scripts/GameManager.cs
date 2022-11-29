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

    // increase number of bricks
    public void IncreaseBrickCount()
    {
        
    }

    // decrease number of bricks
    public void DecreaseBrickCount()
    {
        
    }
}
