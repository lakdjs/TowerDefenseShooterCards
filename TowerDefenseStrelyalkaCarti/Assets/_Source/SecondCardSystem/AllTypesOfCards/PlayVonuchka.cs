using EnemySystem;
using Interfaces;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayVonuchka : APlayCard
    { 
        public CardType CardType { get; private set; } = CardType.EtoYaPostroil;
        private EnemyList _enemyList;
        
        protected override void PlayingCard()
        {
            _enemyList = MonoBehaviour.FindObjectOfType<EnemyList>();
            foreach (var enemy in _enemyList.Enemies)
            {
                enemy.GetComponent<IAoeDamageble>().TakeAoeDamage(10,3);
            }
            Debug.Log("VOnuchka");
        }
    }
}
