using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _cardParentTransform;
    [SerializeField] private CardDeckConfig _cardDeckConfig;
    [SerializeField] private GameSession _gameSession;

    private List<Sprite> _availableSprites = new List<Sprite>();
    private int _cardsAmount;

    public void SpawnCards(int amount)
    {
        _cardsAmount = amount;

        FillAvailableSpritesList();

        if (_gameSession.IsNewGame)
        {
            SpawnCardsForNewGame(SelectSpritesForLayout());
        }

        else
        {
            SpawnPastCardLayoutOnGameContinue();
        }
    }

    private void FillAvailableSpritesList()
    {
        _availableSprites.Clear();

        for (int i = 0; i < _cardDeckConfig.CardFaces.Count; i++)
        {
            _availableSprites.Add(_cardDeckConfig.CardFaces[i]);
        }
    }

    private void SpawnCardsForNewGame(List<Sprite> selectedSprites) 
    {
        ClearPastData();

        for (int i = 0; i < _cardsAmount; i++)
        {
            int r = Random.Range(0, selectedSprites.Count);

            CreateCard(i, selectedSprites[r]);
            _gameSession.CardsLeft++;
            _gameSession.FoundPairs.Add(false);
            _gameSession.SpriteIndexes.Add(_cardDeckConfig.CardFaces.IndexOf(selectedSprites[r]));
            selectedSprites.RemoveAt(r);
        }
    }

    private void SpawnPastCardLayoutOnGameContinue() 
    {
        for (int i = 0; i < _cardsAmount; i++)
        {
            var card = CreateCard(i, _cardDeckConfig.CardFaces[_gameSession.SpriteIndexes[i]]);

            if (_gameSession.FoundPairs[i] == true)
            {
                card.RemoveFromLocation();
            }
        }
    }

    private List<Sprite> SelectSpritesForLayout()
    {
        List<Sprite> selectedSprites = new List<Sprite>(_cardsAmount / 2);

        for (int i = 0; i < _cardsAmount / 2; i++)
        {
            int r = Random.Range(0, _availableSprites.Count);

            for (int j = 0; j < 2; j++)
            {
                selectedSprites.Add(_availableSprites[r]);
            }

            _availableSprites.RemoveAt(r);
        }

        return selectedSprites;
    }

    private void ClearPastData() 
    {
        _gameSession.SpriteIndexes.Clear();
        _gameSession.FoundPairs.Clear();
        _gameSession.CardsLeft = 0;
    }

    private Card CreateCard(int id, Sprite faceSprite)
    {
        var card = Instantiate(_cardPrefab, _cardParentTransform);
        Card cardScript = card.GetComponent<Card>();

        cardScript.Initialize(_gameSession, _cardDeckConfig.CardBack, faceSprite, id);

        return cardScript;
    }


}
