using EnemySystem;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class TiVPive : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.TiVPive;
        private EnemyList _enemyList;
        protected override void PlayingCard()
        {
            _enemyList = MonoBehaviour.FindObjectOfType<EnemyList>();
            for (int i = 0; i < _enemyList.Enemies.Count; i++)
            {
                _enemyList.Enemies[i].GetComponent<EnemyAI>().ChangeMovementSpeedForTime(10,0.33f);
            }
            Debug.Log("TiVPive");
        }
    }
}