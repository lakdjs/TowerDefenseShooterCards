using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace SecondCardSystem
{
    public class CardDragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Camera _cameraMain;
        private Vector3 _offset;
        private DroppingCard _droppingCard;
        private CardView.CardView _cardView;
        public Transform defParent;

        private void Awake()
        {
            _cardView = GetComponent<CardView.CardView>();
            _droppingCard = FindObjectOfType<DroppingCard>(); 
            _cameraMain = Camera.main;
        }

        public void PlayThisCard()
        {
            _cardView.APlayCard.PlayCard();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _offset = transform.position - _cameraMain.ScreenToWorldPoint(eventData.position);
            defParent = transform.parent;
            transform.SetParent(defParent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPos = _cameraMain.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos +  new Vector3(_offset.x, _offset.y, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(defParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
