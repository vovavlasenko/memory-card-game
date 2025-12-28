using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class GameModeButton : MonoBehaviour
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartNewGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartNewGame);
    }

    private void StartNewGame()
    {
        _gameSession.Rows = _rows;
        _gameSession.Columns = _columns;
        _gameSession.IsNewGame = true;
        _mainMenuController.ShowBlackScreenOnNewGameStart();
    }

}
