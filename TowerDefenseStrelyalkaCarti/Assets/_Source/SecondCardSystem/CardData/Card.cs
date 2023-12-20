using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace SecondCardSystem.CardData
{
    [Serializable]
    public class Card
    {
        [field: SerializeField] public CardType CardType { get; private set; }
        [field: SerializeField] public string CardName { get; private set; }
        [field: SerializeField] public Sprite CardLogo { get; private set; }
        [field: SerializeField] public int CardCost { get; private set; }
    }
}
