using UnityEngine;

public class InputManagerMouse : MonoBehaviour
{
    // Stores location of the finger
    Vector3 _fingerLoc;
    private Vector3 _currentLoc;
    private Vector3 _initialLoc;
    private Camera _camera;

    // Update is called once per frame
    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (_camera != null)
        {
            // Convert screen space to world space
            _fingerLoc = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            // Switch off z component as its not required
            _fingerLoc.z = 0f;
        }
        
        // when the finger has just touched the screen
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(_fingerLoc);
        }
        
        // if finger is held
        if (Input.GetMouseButton(0))
        {
            ContinueDrag(_fingerLoc);
        }

        // if finger is lifted
        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
        
        void StartDrag(Vector3 fingerpos)
        {
            // set initial location to the touch location
            _initialLoc = _fingerLoc;
            
            // make the aim line visible and set the starting position of aimline to cannons position
        }

        void ContinueDrag(Vector3 fingerpos)
        {
            _currentLoc = _fingerLoc;
            // if the finger does not travel the min distance from the starting point, we cancel the input
            // if the finger does travel?
            // Start storing the current location of the finger in a new variable
            // Calculate the direction and magnitude of the vector from start position to end position
            // Clamp the vertical component of the direction vector
            // Set the end point of the aim line 
        }

        void EndDrag()
        {
            // remove the aimline
            // Normalise the direction vector
            //Shoot the ball
        }

    }
}
