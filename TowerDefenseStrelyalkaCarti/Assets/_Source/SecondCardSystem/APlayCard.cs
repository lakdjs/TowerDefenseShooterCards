using UnityEngine;

namespace SecondCardSystem
{
    public abstract class APlayCard : ICardPlaying
    {
        protected abstract void PlayingCard();
        public void PlayCard()
        {
            PlayingCard();
        }
    }
}
