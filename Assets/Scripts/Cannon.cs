using UnityEngine;


public class Cannon : MonoBehaviour
{
    // Stores the aim assist line
    public GameObject aimLineGo;
    
    // Balls for the current round
    private int _ballcount;
    
    void Awake()
    {
        // Make aim line disappear
        aimLineGo.SetActive(false);
    }
    
    // set cannon location
    public void BallRemoved(Vector3 position)
    {
        transform.position = position;
    }

    // when mouse button is released
    public void DoOnButtonUp()
    {
        // Make aim line disappear
        aimLineGo.SetActive(false);
    }

    // when mouse button is pressed
    public void DoOnButtonDown()
    {
        // Make aim line disappear
        aimLineGo.SetActive(true);
    }

    // when mouse button is held down
    public void DoOnButtonHold(float angle)
    {
        // Rotate the aim line
        transform.rotation = Quaternion.Euler(0f,0f,angle);
    }

    // Get the number of balls for the round
    public int GetBallCount()
    {
        return _ballcount;
    }
    
    // Increase the number of the balls
    public void IncreaseBallCount()
    {
        _ballcount++;
    }
}
