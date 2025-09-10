using JRPG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal class Enemy : IDamageable
    {
        // <--- Stats --->
        public int MaxHealth { get { return maxHealth; } }
        public int CurrentHealth { get { return currentHealth; } }
        public bool IsAlive => CurrentHealth > 0;

        protected int maxHealth = 10;
        protected int currentHealth;
        protected int damage;

        public Enemy()
        {
            maxHealth = Helper.CalculateRandomRange(maxHealth);
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }
        public void Heal(int amount)
        {
            currentHealth += amount;
        }
    }
}
