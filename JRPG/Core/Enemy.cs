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
        public string Name { get; }
        public int MaxHealth { get { return maxHealth; } }
        public int CurrentHealth { get { return currentHealth; } }
        public bool IsAlive => CurrentHealth > 0;

        public int PoisonDuration { get { return PoisonDuration; } set { poisonDuration = value; } }
        public int StunDuration { get { return PoisonDuration; } set { poisonDuration = value; } }

        private int maxHealth = 10;
        private int currentHealth;
        private int attack = 2;

        private int poisonDuration = 0;
        private int stunDuration = 0;

        public Enemy(string name)
        {
            Name = name;
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
        public int NormalAttack(IDamageable target)
        {
            target.TakeDamage(attack);
            return attack;
        }
    }
}
