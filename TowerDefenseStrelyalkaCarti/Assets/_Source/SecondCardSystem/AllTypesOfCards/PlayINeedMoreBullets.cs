using GunSystem;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayINeedMoreBullets : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.ANEEMOBULEZ;
        private GunReload _gunReload;
        protected override void PlayingCard()
        {
            _gunReload = MonoBehaviour.FindObjectOfType<GunReload>();
            _gunReload.EternalBullets(10);
            Debug.Log("ANEEMOBULEZ");
        }
    }
}