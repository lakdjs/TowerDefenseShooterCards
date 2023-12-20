using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllCards
{
    public class PlayINeedMoreBullets : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.ANEEMOBULEZ;

        protected override void PlayingCard()
        {
            Debug.Log("ANEEMOBULEZ");
        }
    }
}