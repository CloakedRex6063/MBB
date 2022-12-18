using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPan;
    public GameObject levelSelectPanel;

    public void SetMainMenuActive()
    {
        mainMenuPan.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void SetLevelSelectActive()
    {
        mainMenuPan.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}