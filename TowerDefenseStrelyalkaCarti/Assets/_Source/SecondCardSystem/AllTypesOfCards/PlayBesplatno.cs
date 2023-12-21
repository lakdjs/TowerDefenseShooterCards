﻿using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayBesplatno : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.Besplatno;

        protected override void PlayingCard()
        {
            Debug.Log("Besplatno");
        }
    }
}