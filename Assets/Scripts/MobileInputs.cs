using UnityEngine;

public class MobileInputs : MonoBehaviour
{
    private Touch _touch;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
           _touch = Input.GetTouch(0);  
        }
    }
}
