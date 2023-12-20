using SecondCardSystem.AllCards;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.CardView
{
    public class CardViewService 
    {
        private static CardViewService instance;
        private CardSO _cardSo = 
            Resources.Load("Cards" ) as CardSO;
        
        public static CardViewService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardViewService();
                }

                return instance;
            }
        }

        public bool GetCardData(CardType cardType,
            out Sprite cardLogo,
            out string cardName,
            out int cardCost,
            out APlayCard aPlayCard)
        {
            cardLogo = null;
            cardName = null;
            cardCost = 0;
            aPlayCard = null;
            if (_cardSo)
            {
                foreach (var card in _cardSo.Cards)
                {
                    if (card.CardType == cardType)
                    {
                        cardLogo = card.CardLogo;
                        cardName = card.CardName;
                        cardCost = card.CardCost;
                    }
                }

                switch (cardType)
                {
                    case CardType.EtoYaPostroil:
                        aPlayCard = new PlayEtoYaPostroil();
                        break;
                    case CardType.Vonuchka:
                        aPlayCard = new PlayVonuchka();
                        break;
                    case CardType.Besplatno:
                        aPlayCard = new PlayBesplatno();
                        break;
                    case CardType.BABAHHH:
                        aPlayCard = new PlayBABAHHH();
                        break;
                    case CardType.DoctorAyBolit:
                        aPlayCard = new PlayDoctorAyBolit();
                        break;
                    case CardType.SvyatiePuli:
                        aPlayCard = new PlaySvyatiePuli();
                        break;
                    case CardType.ANEEMOBULEZ:
                        aPlayCard = new PlayINeedMoreBullets();
                        break;
                    case CardType.TiVPive:
                        aPlayCard = new TiVPive();
                        break;
                }

                return true;
            }

            return false; 
        }
    }
}
