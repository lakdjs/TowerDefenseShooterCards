using UnityEngine;

namespace EnemySystem
{
    public class EnemySetUpService 
    {
        private static EnemySetUpService instance;
        private EnemyDataSO _enemyDataSo = 
        Resources.Load("enemy1") as EnemyDataSO;
        
        public static EnemySetUpService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemySetUpService();
                }

                return instance;
            }
        }

        public void SetUpEnemy(EnemyTypes enemyType,
            out float enemyHealth,
            out float enemyDamage,
            out int enemyGold,
            out float enemySpeed,
            out float enemyCoolDown)
        {
            enemyHealth = 0;
            enemyDamage = 0;
            enemyGold = 0;
            enemySpeed = 0;
            enemyCoolDown = 0;
            
            foreach (var enemies in _enemyDataSo.EnemyData)
            {
                if (enemyType == enemies.EnemyTypes)
                {
                    enemyHealth = enemies.EnemyHealth;
                    enemyDamage = enemies.Damage;
                    enemyGold = enemies.Gold;
                    enemySpeed = enemies.MovementSpeed;
                    enemyCoolDown = enemies.ShootCoolDown;
                }
            }
        }
    }
}
