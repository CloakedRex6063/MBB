using System.Collections;
using UnityEngine;


public class Cringe : MonoBehaviour
{
    private Vector2 mousepos; 
    public bool boolChange;
    private Camera _camera;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        StartCoroutine(StartGame());
    }
    
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(t);
        boolChange = !boolChange;
        Debug.Log(boolChange);
    }
}
