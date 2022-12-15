using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public List<Sprite> screenShots;
    public Image sprite;
    public TextMeshProUGUI tmp;
    private int curselect = 0;
    private int level = 1;
    
    // Start is called before the first frame update
    public void Next()
    {
        curselect = Mathf.Clamp(curselect+1, 0, screenShots.Count-1);
        level = curselect + 1;
        tmp.text = (curselect+1).ToString();
        sprite.sprite = screenShots[curselect];
    }
    public void Back()
    {
        curselect = Mathf.Clamp(curselect-1, 0, screenShots.Count-1);
        level = curselect + 1;
        tmp.text = (curselect+1).ToString();
        sprite.sprite = screenShots[curselect];
    }

    public void SwitchLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level, LoadSceneMode.Single);
    }
}
