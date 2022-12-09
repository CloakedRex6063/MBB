using GameObjects;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        // Stores location of the finger
        private Vector3 _fingerLoc;
        private Vector3 _currentLoc;
        private Vector3 _initialLoc;
        // Stores reference to camera
        private Camera _camera;
        // Stores the reference to cannon
        private Cannon _cannon;
        // Stores game manager reference
        private GameManager _gm;
        // min finger distance needed to launch balls
        public float mindis = 0.5f;
        private bool _dragStart;
        private float sensi = 1f;
        FingerFeedback fingerFeedback;

        public void Awake()
        {
            _cannon = FindObjectOfType<Cannon>();
            _gm = GetComponent<GameManager>();
            fingerFeedback = FindObjectOfType<FingerFeedback>();

            fingerFeedback.SetThreshold(mindis);
        }

        // Update is called once per frame
        public void Start()
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
                fingerFeedback.StartDrag(_fingerLoc);
            }
        
            // if finger is held
            if (Input.GetMouseButton(0))
            {
                ContinueDrag(_fingerLoc);
                fingerFeedback.Dragging((_fingerLoc));
            }

            // if finger is lifted
            if (Input.GetMouseButtonUp(0))
            {
                // Aim line disappears
                _cannon.DoOnButtonUp();
                fingerFeedback.EndDrag();
                // if drag distance is more than required min distance then launch the balls
                if ((_initialLoc - _currentLoc).magnitude >= mindis)
                {
                    // End Drag z
                    EndDrag();
                }
            }
        }
    
        void StartDrag(Vector3 fingerpos)
        {
            _dragStart = true;
            // set initial location to the touch location
            _initialLoc = fingerpos;
        }

        void ContinueDrag(Vector3 fingerpos)
        {
            if (_dragStart)
            {
                // Start storing the current location of the finger in a new variable
                _currentLoc = fingerpos;
                // Store the difference between starting and end drag position
                Vector2 diff = sensi * (_initialLoc-_currentLoc);
                diff.y = Mathf.Max(0.3f, _initialLoc.y - _currentLoc.y);
                // Get tan inverse of the difference between the drag positions and convert it into degrees
                float angle = Mathf.Rad2Deg * Mathf.Atan(diff.x/diff.y);
                if ((_initialLoc - _currentLoc).magnitude >= mindis)
                {
                    _cannon.DoOnButtonHold(-angle);   
                }
            }
        }

        void EndDrag()
        {
            // Shoot the balls
            StartCoroutine(_cannon.LoopShoot());
            // Change the game state to action 
            _gm.ChangeState(GameManager.GameState.Wait);
            _initialLoc = Vector3.zero;
            _currentLoc = Vector3.zero;
            _dragStart = false;
        }

        // Change if the input manager is enabled or not
        public void ToggleInputManager(bool toggle)
        {
            enabled = toggle;
        }
    }
}
