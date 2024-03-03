using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private Game _game;
    private void Awake()
    {
        _gameManager.Initialized();
        _menuManager.Initialized();
        _game.Initialized();
    }
}
