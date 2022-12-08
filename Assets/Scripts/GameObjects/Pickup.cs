using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Cannon _cannon;
    // Start is called before the first frame update
    void Start()
    {
        // Store the reference to the cannon
        _cannon = FindObjectOfType<Cannon>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Returns the ball component of the colliding object
        Ball colBall = col.gameObject.GetComponent<Ball>();
        // if there is a ball component
        if (colBall)
        {
            // increase the round ball count
            _cannon.IncreaseBallCount();
            // destroy the pickup
            Destroy(this);
        }
    }
}
