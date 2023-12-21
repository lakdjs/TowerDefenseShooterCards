using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class TiVPive : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.TiVPive;

        protected override void PlayingCard()
        {
            Debug.Log("TiVPive");
        }
    }
}