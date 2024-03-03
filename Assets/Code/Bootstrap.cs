using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private Game _game;
    [SerializeField] private CardDraw _cardDraw;
    
    private void Awake()
    {
        _gameManager.Initialized();
        _menuManager.Initialized();
        _game.Initialized();
        _cardDraw.Initialized();
    }
}
