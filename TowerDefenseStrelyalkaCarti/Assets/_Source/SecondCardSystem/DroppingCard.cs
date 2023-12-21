using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SecondCardSystem
{
    public class DroppingCard : MonoBehaviour, IDropHandler
    {
        public event Action<bool> OnCardPlayed; 
        public void OnDrop(PointerEventData eventData)
        {
            CardDragging card = eventData.pointerDrag.GetComponent<CardDragging>();

            if (card)
            {
                card.PlayThisCard();
                card.defParent = transform;
                Destroy(card.gameObject);
            }
        }
    }
}
