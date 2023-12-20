using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllCards
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
