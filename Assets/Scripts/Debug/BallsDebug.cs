using Managers;
using TMPro;
using UnityEngine;

public class BallsDebug : MonoBehaviour
{
    private GameManager _gm;
    public TextMeshProUGUI _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.text = _gm.GetBallCount().ToString();
    }
}
