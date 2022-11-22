using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Touch _touch;
    private Vector3 initialLoc;
    private Vector3 CurrentLoc;
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

        if (_touch.phase == TouchPhase.Began)
        {
            Ray ray = _camera.ScreenPointToRay(_touch.position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null) 
                {
                    GameObject touchedObject = hit.transform.gameObject;
                    Debug.Log("Touched " + touchedObject.transform.name);
                }
            }
        }
        
    }
}
