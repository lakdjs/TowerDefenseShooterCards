using System;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyList : MonoBehaviour
    {
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

        private void Start()
        {
            //Enemies = new List<Enemy>();
        }

        public void AddEnemyInList(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void RemoveEnemyFromList(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }

        public void StopAllEnemies()
        {
            foreach (var enemy in Enemies)
            {
                enemy.gameObject.GetComponent<EnemyAI>().enabled = false;   
                enemy.gameObject.GetComponent<EnemyCombat>().enabled = false;   
            }
        }
    }
}
