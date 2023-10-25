using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyList : MonoBehaviour
    {
        public List<Enemy> Enemies { get; private set; }

        public void AddEnemyInList(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void RemoveEnemyFromList(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
