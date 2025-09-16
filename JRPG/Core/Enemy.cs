using JRPG.Systems;
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

        public int PoisonDuration { get { return poisonDuration; } set { poisonDuration = value; } }
        public int StunDuration { get { return stunDuration; } set { stunDuration = value; } }
        public int PoisonDamage { get { return poisonDamage; } set { poisonDamage = value; } }

        private int maxHealth = 5;
        private int currentHealth;
        private int attack = 3;
        private int difficultyModifier = 1;

        private int stunDuration = 0;
        private int poisonDuration = 0;
        private int poisonDamage = 0;

        public Enemy(string name, int difficultyModifier)
        {
            Name = name;
            this.difficultyModifier = difficultyModifier;
            maxHealth = Helper.CalculateRandomRange(maxHealth * this.difficultyModifier);
            currentHealth = maxHealth;
            attack = Helper.CalculateRandomRange(attack * this.difficultyModifier);
        }
        
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0) CombatManager.enemies.Remove(this);
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
