using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Recall : MonoBehaviour
{
    private PoolManager _pm;
    private GameManager _gm;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _pm = FindObjectOfType<PoolManager>();
        _gm = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        if(_button)
        {
            _button.onClick.AddListener(delegate { OnClickRecall(); });
        }
    }

     void OnClickRecall()
    {
        for (int i = 0; i < _pm.GetBallCount(); i++)
        {
            //Instantiate(Blueprint to be spawned, where to spawn it, at what angle to be spawned)
            GameObject activedBall = _pm.MakeInactive();
            if (activedBall != null)
            {
                activedBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }         
        }
        _gm.ChangeState(GameManager.GameState.Prep);
    }
    
}
