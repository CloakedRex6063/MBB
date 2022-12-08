using Managers;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hp;
    private GameManager _gm;
    private TextMeshPro _tmp;
    public void Start()
    {
        // Find the game manager and store a reference to it
        _gm = FindObjectOfType<GameManager>();

        _tmp = GetComponentInChildren<TextMeshPro>();
        // Each brick is added to the game manager's brick count
        _gm.IncreaseBrickCount();
        if (_tmp)
        {
            _tmp.text = hp.ToString();   
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Returns the ball component of the colliding object
        Ball colBall = col.gameObject.GetComponent<Ball>();
        // if there is a ball component
        if (colBall)
        {
            // damage the brick
            Damage();
        }
    }

    private void Damage()
    {
        // Decrease hp
        hp--;
        if (_tmp)
        { 
            _tmp.text = hp.ToString();   
        }
        // if hp is now 0 or below 
        if (hp <= 0)
        {
            // decrease the brick count
            _gm.DecreaseBrickCount();
            // destroy the brick
            Destroy(gameObject);
        }
    }
}

