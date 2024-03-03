using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged; 
    
    public void Initialized()
    {
        Instance = this;
        UpdateGameState(GameState.PlayerTurn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlayerTurn()
    {
        
    }
}

public enum GameState{
    PlayerTurn,
}
