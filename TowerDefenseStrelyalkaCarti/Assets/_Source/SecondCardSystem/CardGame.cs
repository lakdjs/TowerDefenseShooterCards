using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SecondCardSystem
{
    public class CardGame
    {
        private List<CardView.CardView> _deck;
        private List<CardView.CardView> _hand;

        public CardGame()
        {
            _deck = GiveDeckCards();
            _hand = new List<CardView.CardView>();
        }

        List<CardView.CardView> GiveDeckCards()
        {
            List<CardView.CardView> list = new List<CardView.CardView>();
            foreach (var card in AllCards.Cards)
            {
                list.Add(AllCards.Cards[Random.Range(0,AllCards.Cards.Count)]);
            }

            return list;
        }
    }
}
