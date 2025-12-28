using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _cardImage;
    
    public static event Action CardTouched;
    public static event Action<Card> CardRevealed;

    private GameSession _gameSession;

    private Sprite _faceSprite;
    private Sprite _backSprite;

    private bool _canRotate = true;
    private bool _pairWasFound = false;

    private int _id;

    public Sprite FaceSprite { get => _faceSprite; }

    public void Initialize(GameSession gameSession, Sprite backSprite, Sprite faceSprite, int id)
    {
        _gameSession = gameSession;
        _backSprite = backSprite;
        _faceSprite = faceSprite;
        _cardImage.sprite = _backSprite;
        _id = id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canRotate && !_pairWasFound)
        {
            CardTouched?.Invoke();
            StartRevealingCard();
        }
    }

    private void StartRevealingCard()
    {
        _canRotate = false;
        CardFlipWithCallback(90f, FinishRevealingCard);
    }

    private void CardFlipWithCallback(float angle, Action callback)
    {
        Tween t = _cardImage.transform.DORotate(new Vector3(0f, angle, 0f), 0.25f);
        t.OnComplete(() => callback());
    }

    private void FinishRevealingCard()
    {
        _cardImage.sprite = _faceSprite;
        CardFlipWithCallback(180f, OnCardRevealed);
    }

    public void StartUnrevealingCard()
    {
        CardFlipWithCallback(90f, FinishUnrevealingCard);
    }

    private void FinishUnrevealingCard()
    {
        _cardImage.sprite = _backSprite;
        CardFlipWithCallback(0f, EnableRotating);
    }

    private void EnableRotating()
    {
        _canRotate = true;
    }

    private void OnCardRevealed()
    {
        CardRevealed?.Invoke(this);
    }

    public void OnPairFound()
    {
        _canRotate = false;
        _pairWasFound = true;
        _cardImage.transform.DOScale(0, 0.5f);
        _gameSession.FoundPairs[_id] = true; 
    }

    public void RemoveFromLocation()
    {
        _cardImage.transform.localScale = Vector3.zero;
    }

}
