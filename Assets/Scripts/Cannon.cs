using System.Collections;
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
    public int _ballcount = 10;
    
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

    public void Shoot()
    {
        GameObject createdball = Instantiate(ball,transform.position,Quaternion.identity);
        createdball.GetComponent<Rigidbody2D>().AddForce(transform.up * ballspeed,ForceMode2D.Impulse);
    }

    public void BallRemoved(Vector3 transformPosition)
    {
        transform.position = transformPosition;
        transform.rotation = Quaternion.identity;
        _gm.ChangeState(GameManager.GameState.Prep);
    }

    public IEnumerator LoopShoot()
    { 
        for (int i = 0; i < _ballcount; i++)
        {
            yield return new WaitForSeconds(shootspeed);
            Shoot();
        }
    }
}
