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
        if (_gm.GetBallCount() == _ballcount)
        {
            var transform1 = transform;
            transform1.position = transformPosition;
            transform1.rotation = Quaternion.identity;
        }
        else if (_gm.GetBallCount() == 1)
        {
            _gm.ChangeState(GameManager.GameState.Prep);
        }
    }

    public IEnumerator LoopShoot()
    { 
        for (int i = 0; i < _ballcount; i++)
        {
            Shoot();
            yield return new WaitForSeconds(shootspeed);
        }
    }
}
