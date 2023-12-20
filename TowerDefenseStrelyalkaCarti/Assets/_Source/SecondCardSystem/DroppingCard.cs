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
                //OnCardPlayed?.Invoke(true);
                card.PlayThisCard(true);
                card.defParent = transform;
                Destroy(card.gameObject);
            }
        }
    }
}
