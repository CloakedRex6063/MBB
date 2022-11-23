using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Touch _touch;
    Vector3 _touchLoc;
    private Vector3 _currentLoc;
    private Vector3 _initialLoc;
    private Camera _camera;
    private List<Vector2> _aimLine;

    // Update is called once per frame
    private void Start()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);  
        }
        
        // Convert screen space to world space
        if (_camera != null)
        {
            _touchLoc = _camera.ScreenToWorldPoint(_touch.position);
            _touchLoc.z = 0f;
        }

        // when touch has just began
        if (_touch.phase == TouchPhase.Began)
        {
            StartDrag(_touchLoc);
        }
        
        // when finger is moved across the screen
        if (_touch.phase == TouchPhase.Moved)
        {
            ContinueDrag(_touchLoc);
        }
    }

    void StartDrag(Vector3 fingerpos)
    {
        // set initial location to the touch location
        _initialLoc = _touchLoc;
    }

    void ContinueDrag(Vector3 fingerpos)
    {
        // if the finger does not travel the min distance from the starting point, we cancel the input
        _currentLoc = _touchLoc;
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
