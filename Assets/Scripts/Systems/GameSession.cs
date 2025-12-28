using System.Collections.Generic;
using UnityEngine;

// Keeps runtime state for the current game session.
// I use ScriptableObject to persist progress between scenes.

[CreateAssetMenu]
public class GameSession : ScriptableObject
{
    public int Rows;
    public int Columns;

    public List<int> SpriteIndexes;
    public List<bool> FoundPairs;

    public int Score;
    public int CardsLeft;
    public bool IsNewGame;
    public bool CanContinueSession;
}
