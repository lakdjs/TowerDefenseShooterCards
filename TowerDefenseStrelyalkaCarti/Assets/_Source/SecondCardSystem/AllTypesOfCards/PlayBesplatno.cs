using Interfaces;
using SecondCardSystem.CardData;
using TowerSystem;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayBesplatno : APlayCard
    {
        private TowerList _towerList;
        public CardType CardType { get; private set; } = CardType.Besplatno;

        protected override void PlayingCard()
        {
            _towerList = MonoBehaviour.FindObjectOfType<TowerList>();
            for (int i = 0; i < _towerList.Towers.Count; i++)
            {
                _towerList.Towers[i].GetComponent<IDamageble>().TakeDamage(-1);
            }
            Debug.Log("Besplatno");
        }
    }
}