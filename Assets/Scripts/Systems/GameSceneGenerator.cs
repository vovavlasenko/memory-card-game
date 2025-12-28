using UnityEngine;
using UnityEngine.UI;

public class GameSceneGenerator : MonoBehaviour
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private CardSpawner _cardSpawner;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private GridLayoutGroup _grid;

    private int _rows;
    private int _columns;
    private float _spacingX;
    private float _spacingY;
    private float _maxPossibleCardWidth;
    private float _maxPossibleCardHeight;

    private void Start()
    {
        GetLayoutInfo();
        CalculateMaxPossibleCardSize();
        SetGridSpacing();
        SetGridConstraint();
        SetFinalCardSize();
        SpawnCards();
        _gameSession.CanContinueSession = true;
    }
    
    private void GetLayoutInfo()
    {
        _rows = _gameSession.Rows;
        _columns = _gameSession.Columns;
    }

    private void CalculateMaxPossibleCardSize() // Based on size of safe zone and card layout
    {
        _maxPossibleCardWidth = _rectTransform.sizeDelta.x / _columns;
        _maxPossibleCardHeight = _rectTransform.sizeDelta.y / _rows;
    }

    private void SetGridSpacing() // Spacing between the cards is calculated as 10% from max card size
    {       
        _spacingX = _maxPossibleCardWidth / 10;
        _spacingY = _maxPossibleCardHeight / 10;
        _grid.spacing = new Vector2(_spacingX, _spacingY);
    }

    private void SetGridConstraint()
    {
        _grid.constraintCount = _rows;
    }

    private void SetFinalCardSize()
    {
        float cardWidth = _maxPossibleCardWidth - _spacingX;
        float cardHeight = _maxPossibleCardHeight - _spacingY;
        float cardSide = Mathf.Min(cardWidth, cardHeight); 
        _grid.cellSize = new Vector2(cardSide, cardSide); // Making card square-shaped
    }

    private void SpawnCards()
    {
       _cardSpawner.SpawnCards(_rows * _columns);
    }

}
