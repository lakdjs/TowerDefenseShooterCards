using CharacterSystem;
using Interfaces;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayDoctorAyBolit : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.DoctorAyBolit;
        private Character _character;
        protected override void PlayingCard()
        {
            _character = MonoBehaviour.FindObjectOfType<Character>();
            IDamageble playerHealth = _character.GetComponent<IDamageble>();
            playerHealth.TakeDamage(-50);
            Debug.Log("EtoDoctorAyBolit");
        }
    }
}
