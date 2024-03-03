using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;

    private const int COUNT_CARDS = 24;
    private List<int> deck;
    public List<Player> players;

    private int indexPlayer = -1;
    private bool isEnd;
    private DateTime timer;

    public static Game Instance;
    
    /// <summary>
    /// Метод который вызывается при инициализации игры в классе Bootstrap
    /// </summary>
    public void Initialized()
    {
        Instance = this;
        
        deck = randomDeck(COUNT_CARDS);

        for (int i = 0; i < _gameSettings.CountPlayer; i++)
        {
            players.Add(new Player());
            GetCard(4, players[i]);
        }

        players[0].IsTurn = true;
        StartTimer();
    }

    private void Update()
    {
        if (DateTime.Now - timer >= TimeSpan.FromSeconds(_gameSettings.TurnTime))
        {
            players[indexPlayer].IsTurn = false;
            players[indexPlayer].IsTurn = true;
            StartTimer();
        }
    }

    /// <summary>
    /// Таймер ходов игроков
    /// </summary>
    private void StartTimer()
    {
        if (isEnd) return;
        
        timer = DateTime.Now;
        indexPlayer++;

        int countHip = 0;
        foreach (var player in players)
        {
            if (player.isHip) countHip++;
            if (countHip == _gameSettings.CountPlayer - 1) isEnd = true;
        }
        
        if (indexPlayer == _gameSettings.CountPlayer) indexPlayer = 0;
        Debug.Log(indexPlayer);
    }

    /// <summary>
    /// Выдать карты игроку из колоды
    /// </summary>
    /// <param name="count">количество карт</param>
    /// <param name="player">Игрок которому нужно выдать карту</param>
    private void GetCard(int count, Player player)
    {
        for (int i = 0; i < count; i++)
        {
            player.cards.Add(deck[0]);
            deck.RemoveAt(0);   
        }
    }
    
    /// <summary>
    /// Случайное формирование колоды
    /// </summary>
    /// <param name="count">Количество карт в колоде</param>
    /// <returns></returns>
    private List<int> randomDeck(int count)
    {
        List<int> deck = new List<int>();
        deck.Add(Random.Range(1, count + 1));
        for (int i = 0; i < count - 1; i++)
        {
            int newValue = Random.Range(1, count + 1);
            while (deck.Exists(item => item == newValue))
            {
                newValue = Random.Range(1, count + 1);
            }

            deck.Add(newValue);
        }

        return deck;
    }
}

public class Player
{
    public List<int> cards = new List<int>();
    public bool isHip = false;
    public bool IsTurn = false;
}
