using System;
using UnityEngine;

namespace GameObjects
{
    public class Pickup : MonoBehaviour
    {
        private Cannon _cannon;
        // Start is called before the first frame update
        void Start()
        {
            // Store the reference to the cannon
            _cannon = FindObjectOfType<Cannon>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Returns the ball component of the colliding object
            Ball colBall = col.GetComponent<Ball>();
            // if there is a ball component
            if (colBall)
            {
                // increase the round ball count
                _cannon.DoOnPickup();
                // destroy the pickup
                Destroy(gameObject);
            }
        }
    }
}
