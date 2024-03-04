using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDraw : MonoBehaviour
{
    private Game _game;

    [SerializeField] private List<Image> _hands;
    [SerializeField] private GameSettings _gameSettings;

    void Start()
    {
        _game = GameObject.Find("Game").GetComponent<Game>();
    }

    void Update()
    {
        //_hands[_game.indexPlayer].fillAmount = _gameSettings.TurnTime / 100 * (DateTime.Now - _game.timer).Seconds;
    }
}
