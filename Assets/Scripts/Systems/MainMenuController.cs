using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private BlackScreen _blackScreen;
    [SerializeField] private Button _continueButton;

    private void Start()
    {
        UpdateInterface();
    }

    public void ShowBlackScreenOnNewGameStart()
    {
        _blackScreen.Show(StartNewGame);
    }

    private void StartNewGame()
    {
        _gameSession.IsNewGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowBlackScreenOnGameContinue()
    {
        _blackScreen.Show(ContinueGame);
    }

    private void ContinueGame()
    {
        _gameSession.IsNewGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void UpdateInterface()
    {
        if (_gameSession.CanContinueSession)
        {
            _continueButton.interactable = true;
        }

        else
        {
            _continueButton.interactable = false;
        }
    }
}
