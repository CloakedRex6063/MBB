using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        var main = Camera.main;
        if (main != null)
        {
            main.orthographicSize = 1920/(100f *2f) * ((9f / 16f) / main.aspect);
        }
    }
}
