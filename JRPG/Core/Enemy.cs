using JRPG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal class Enemy
    {
        protected int maxHealth = 10;
        protected int currentHealth;
        protected int damage;

        public int MaxHealth {  get { return maxHealth; } }
        public int CurrentHealth {  get { return currentHealth; } }

        public Enemy()
        {
            maxHealth = Helper.CalculateRandomRange(maxHealth);
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }
    }
}
