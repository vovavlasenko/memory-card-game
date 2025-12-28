using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardDeckConfig : ScriptableObject
{
    public Sprite CardBack;
    public List<Sprite> CardFaces;
}
