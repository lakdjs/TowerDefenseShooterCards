using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayDoctorAyBolit : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.DoctorAyBolit;

        protected override void PlayingCard()
        {
            Debug.Log("EtoDoctorAyBolit");
        }
    }
}
