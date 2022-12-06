using System.Collections;
using Managers;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    // Stores the aim assist line
    public GameObject aimLineGo;
    public float ballspeed = 10f;
    public float shootspeed = 0.1f;
    public GameObject ball;
    private GameManager _gm;

    // Balls for the current round
    public int ballcount = 10;
    public int removedballs;
    
    void Awake()
    {
        // Make aim line disappear
        aimLineGo.SetActive(false);
        _gm = FindObjectOfType<GameManager>();
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
        
    }

    // when mouse button is held down
    public void DoOnButtonHold(float angle)
    {
        // Make aim line disappear
        aimLineGo.SetActive(true);
        // Rotate the aim line
        transform.rotation = Quaternion.Euler(0f,0f,angle);
    }

    // Get the number of balls for the round
    public int GetBallCount()
    {
        return ballcount;
    }

    private void Shoot()
    {
        GameObject createdball = Instantiate(ball,transform.position,Quaternion.identity);
        createdball.GetComponent<Rigidbody2D>().AddForce(transform.up * ballspeed,ForceMode2D.Impulse);
    }

    public void BallRemoved(Vector3 transformPosition)
    {
        removedballs++;
        if (removedballs == 1)
        {
            transform.position = transformPosition;
        }
        else if (removedballs == ballcount)
        {
            _gm.ChangeState(GameManager.GameState.Prep);
            removedballs = 0;
        }
    }

    public IEnumerator LoopShoot()
    { 
        for (int i = 0; i < ballcount; i++)
        {
            Shoot();
            yield return new WaitForSeconds(shootspeed);
        }
        yield return new WaitForSeconds(0.5f);
        _gm.ChangeState(GameManager.GameState.Action);
        ResetCannonAngle();
    }

    private void ResetCannonAngle()
    {
        transform.rotation = Quaternion.identity;
    }

    public void IncreaseBallCount()
    {
        ballcount++;
    }
    
    public void DecreaseBallCount()
    {
        ballcount--;
    }
}
