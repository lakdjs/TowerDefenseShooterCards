using System;
using SecondCardSystem.CardData;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SecondCardSystem.CardView
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private CardType cardType;
        [SerializeField] private Image cardLogo;
        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private TextMeshProUGUI cardCostText;
        private int _cardCost;
        public int CardCost => _cardCost;
        private APlayCard _aPlayCard;
        public APlayCard APlayCard => _aPlayCard;

        private void Start()
        {
            if(CardViewService.Instance.GetCardData(cardType,
                   out Sprite spriteLogo,
                   out string cardName,
                   out _cardCost,
                   out _aPlayCard))
            {
                cardLogo.sprite = spriteLogo;
                cardNameText.text = cardName;
                cardCostText.text = _cardCost.ToString();
            }
        }
    }
}
