using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Game Setings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int _turnTime;
    [SerializeField] private int _countPlayer;
    [SerializeField] private Sprite _backSpriteCard;

    public int TurnTime => _turnTime;
    public int CountPlayer => _countPlayer;
    public Sprite BackSpriteCard => _backSpriteCard;

    [Serializable]
    public class Card
    {
        [SerializeField] private int _id;
        [SerializeField] private int _weight;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _image;

        public int Id => _id;
        public string Name => _name;
        public int Weight => _weight;
        public Sprite Image => _image;
    }

    [SerializeField] private Card[] _deck;

    public Card[] Deck => _deck;
}
