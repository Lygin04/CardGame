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

    [SerializeField] private Image _card;
    
    public void Initialized()
    {
        _game = GameObject.Find("Game").GetComponent<Game>();
        _card.sprite = _gameSettings.Deck[_game.indexCard].Image;
        for (int i = 0; i < _gameSettings.CountPlayer; i++)
        {
            for (int j = 0; j < _game.players[i].cards.Count; j++)
            {
                GameObject newCard = Instantiate(_cardPref, _hands[i].transform);
                newCard.GetComponent<Card>().countPlayer = i;
                if(i == 0)
                    newCard.GetComponent<Image>().sprite = _gameSettings.Deck[_game.players[i].cards[j]].Image;
                else
                    newCard.GetComponent<Image>().sprite = _gameSettings.BackSpriteCard;
            }
        }
    }

    private void Update()
    {
       
    }
}
