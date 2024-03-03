using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CardDraw : MonoBehaviour
{
    private Game _game;
    
    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private GameObject _cardPref;
    [SerializeField] private List<GameObject> _hands;
    
    
    public void Initialized()
    {
        _game = GameObject.Find("Game").GetComponent<Game>();
        for (int i = 0; i < _gameSettings.CountPlayer; i++)
        {
            foreach (var t in _game.players[i].cards)
            {
                GameObject newCard = Instantiate(_cardPref, _hands[i].transform);
                newCard.GetComponent<Image>().sprite = _gameSettings.Deck[t].Image;
            }
        }
    }

    private void Update()
    {
       
    }
}
