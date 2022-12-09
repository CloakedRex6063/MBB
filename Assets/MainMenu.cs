using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    public enum LevelNumber
    {
        LEVEL1 = 1,
        LEVEL2 = 2,
        LEVEL3 = 3,
        LEVEL4 = 4,
        LEVEL5 = 5,
        LEVEL6 = 6
    }

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


    public void SwitchLevel(int levelNumber)
    {
        switch ((LevelNumber) levelNumber)
        {
            case LevelNumber.LEVEL1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                break;

            case LevelNumber.LEVEL2:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
                break;

            case LevelNumber.LEVEL3:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3, LoadSceneMode.Single);
                break;

            case LevelNumber.LEVEL4:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4, LoadSceneMode.Single);
                break;

            case LevelNumber.LEVEL5:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5, LoadSceneMode.Single);
                break;

            case LevelNumber.LEVEL6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6, LoadSceneMode.Single);
                break;

        }
    }
}