using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManagerMouse : MonoBehaviour
{
    // Stores location of the finger
    private Vector3 _fingerLoc;
    private Vector3 _currentLoc;
    private Vector3 _initialLoc;
    // Stores camera
    private Camera _camera;
    // Stores the aim assist line
    private GameObject _aimAssist;
    // Stores the cannon
    private GameObject _cannon;
    // min finger distance needed to launch balls
    public float mindis = 0.5f;
    private LineRenderer _aimLine;
    public float aimLineLength = 6f;

    private void Awake()
    {
        // Find the game object named AimAsset and store it.
        _aimAssist = GameObject.Find("AimAssist");
        // Find the game object named Cannon and store it.
        _cannon = GameObject.Find("Cannon");
        // Set the aim line reference
        _aimLine = _aimAssist.GetComponent<LineRenderer>();
        // Disable it 
        _aimAssist.SetActive(false);
    }

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
            // Set aim assist to inactive
            _aimAssist.SetActive(false);
            // if drag distance is more than required min distance then launch the balls
            if ((_initialLoc - _currentLoc).magnitude >= mindis)
            {
                EndDrag();
            }
        }
        
        void StartDrag(Vector3 fingerpos)
        {
            // set initial location to the touch location
            _initialLoc = fingerpos;
            
            // make the aim line visible and set the starting position of aimline to cannons position
        }

        void ContinueDrag(Vector3 fingerpos)
        {
            // Start storing the current location of the finger in a new variable
            _currentLoc = fingerpos;
        
            // Make the aimline visible
            _aimAssist.SetActive(true);
            _aimAssist.transform.position = _cannon.transform.position;
            _aimLine.SetPosition(1,new Vector3(0f,aimLineLength,0f));

            // Store the difference between starting and end drag position
            Vector2 diff = _initialLoc-_currentLoc;
            diff.y = Mathf.Max(0.25f, _initialLoc.y - _currentLoc.y);
            // Get tan inverse of the difference between the drag positions and convert it into degrees
            float angle = Mathf.Rad2Deg * Mathf.Atan(diff.x/diff.y);
            // Rotate the aim line
            _aimAssist.transform.rotation = Quaternion.Euler(0f,0f,-angle);
        }

        void EndDrag()
        {
            // Normalise the direction vector
            //Shoot the ball
            
        }

    }
}
