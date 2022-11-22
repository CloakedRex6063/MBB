using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Touch _touch;
    private Vector3 initialLoc;
    private Vector3 CurrentLoc;
    private float _time;
    private float _mindis = 0.3f;
    public Vector3 _touchLoc;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
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
        
        BeginTouch();
        HoldTouch();
        EndTouch();
        
    }
    void BeginTouch()
    {
        if (_touch.phase == TouchPhase.Began)
        {
            _time = 0.5f;
            initialLoc = _touch.position;
            initialLoc = CurrentLoc;
        }
    }

    void HoldTouch()
    {
        if (_touch.phase == TouchPhase.Moved)
        {
            _time -= Time.deltaTime;
            CurrentLoc = _touch.position;
        }
    }

    void EndTouch()
    {
        if (_time > 0 && _touch.phase == TouchPhase.Ended)
        {
            Vector3 vector3dis = CurrentLoc - initialLoc;
            float dis = vector3dis.magnitude;
            if (dis > _mindis)
            {
                Debug.Log("Swipe Registered");
                initialLoc = CurrentLoc;
            }
        }
    }
}


