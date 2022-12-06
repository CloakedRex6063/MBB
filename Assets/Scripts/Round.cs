using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    private GameManager _gm;

    private TextMeshPro _textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = _gm.currentRounds == 0 ? 1.ToString() : _gm.currentRounds.ToString();
        _textMeshPro.text = "Round " + text;
    }
}