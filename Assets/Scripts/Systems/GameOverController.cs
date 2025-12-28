using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private BlackScreen _blackScreen;

    private void OnEnable()
    {
        CardComparator.PairFound += CheckWinCondition;
    }

    private void OnDisable()
    {
        CardComparator.PairFound -= CheckWinCondition;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CheckWinCondition(int i)
    {
        if (_gameSession.CardsLeft == 0)
        {
            GameOver();
        }    
    }

    private void GameOver()
    {
        _soundSystem.PlayGameOverSound();
        _gameSession.CanContinueSession = false;
        _blackScreen.Show(ExitToMainMenu);
    }

}
