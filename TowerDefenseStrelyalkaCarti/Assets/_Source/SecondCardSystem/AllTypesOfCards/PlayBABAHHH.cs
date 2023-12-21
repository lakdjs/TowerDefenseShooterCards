using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayBABAHHH : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.BABAHHH;

        protected override void PlayingCard()
        {
            Debug.Log("BABAHHH");
        }
    }
}