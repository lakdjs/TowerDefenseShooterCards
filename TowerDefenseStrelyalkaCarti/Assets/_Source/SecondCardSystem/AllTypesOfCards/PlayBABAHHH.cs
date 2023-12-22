using System.Collections.Generic;
using EnemySystem;
using Interfaces;
using SecondCardSystem.CardData;
using UnityEngine;

namespace SecondCardSystem.AllTypesOfCards
{
    public class PlayBABAHHH : APlayCard
    {
        public CardType CardType { get; private set; } = CardType.BABAHHH;
        private EnemyList _enemyList;
        protected override void PlayingCard()
        { 
            _enemyList = MonoBehaviour.FindObjectOfType<EnemyList>();
            for(int i = 0; i < _enemyList.Enemies.Count; i++)
            {
               Debug.Log(_enemyList.Enemies[i]);
               _enemyList.Enemies[i].GetComponent<IDamageble>().TakeDamage(1000);
            }
            Debug.Log("BABAHHH");
        }
    }
}