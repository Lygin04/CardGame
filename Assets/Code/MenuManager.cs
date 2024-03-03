using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerTurn;
    
    public void Initialized()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _playerTurn.SetActive(state == GameState.PlayerTurn);
    }
}
