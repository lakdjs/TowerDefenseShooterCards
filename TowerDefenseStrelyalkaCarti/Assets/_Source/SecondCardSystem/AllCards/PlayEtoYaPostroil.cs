using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllCards
{
    public class PlayEtoYaPostroil : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.EtoYaPostroil;

        protected override void PlayingCard()
        {
            Debug.Log("EtoYaPostroil");
        }
    }
}
