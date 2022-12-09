using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadMenu());
    }

    IEnumerator ReloadMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
