using System;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private SoundSystem _soundSystem;

    public static event Action<int> PairFound;

    private Card _firstCard;
    private Card _secondCard;
    private int _comboMultiplier;

    private void OnEnable()
    {
        Card.CardRevealed += OnCardSelect;
    }

    private void OnDisable()
    {
        Card.CardRevealed -= OnCardSelect;
    }

    public void OnCardSelect(Card card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }

        else
        {
            _secondCard = card;
            CompareCards();
            _firstCard = null;
        }
    }

    private void CompareCards()
    {
        if (_firstCard.FaceSprite == _secondCard.FaceSprite)
        {
            CardsMatched();
        }

        else
        {
            CardsMismatched();
        }
    }

    private void CardsMatched()
    {
        _gameSession.CardsLeft -= 2;
        _comboMultiplier++;
        _soundSystem.PlayMatchSound();
        _firstCard.OnPairFound();
        _secondCard.OnPairFound();
        PairFound?.Invoke(_comboMultiplier);
    }

    private void CardsMismatched()
    {
        _comboMultiplier = 0;
        _soundSystem.PlayMismatchSound();
        _firstCard.StartUnrevealingCard();
        _secondCard.StartUnrevealingCard();
    }
}
