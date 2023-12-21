using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlaySvyatiePuli : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.SvyatiePuli;

        protected override void PlayingCard()
        {
            Debug.Log("SvyatiePuli");
        }
    }
}