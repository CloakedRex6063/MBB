using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager _gm;
    private Cannon _cannon;
    private BottomLine _bl;

    // Start is called before the first frame update
    void Start()
    {
        // Find the game manager and store a reference to it
        _cannon = FindObjectOfType<Cannon>();

        // Find the game manager and store a reference to it
        _gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if ball has gone below the bottom line
        if (transform.position.y < _bl.transform.position.y)
        {
            // set the cannon's x axis using the ball's x axis position
            _cannon.BallRemoved(transform.position);
        }
    }
}
