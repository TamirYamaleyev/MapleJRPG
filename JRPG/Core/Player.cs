using JRPG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal class Player : IDamageable
    {
        // Player Damage Cap
        const int damageCap = 999;

        // <--- Stats --->
        public int MaxHealth { get { return maxHealth; } }
        public int CurrentHealth { get { return maxHealth; } }
        public bool IsAlive => CurrentHealth > 0;

        protected int maxHealth = 100;
        protected int currentHealth;
        protected int attack = 1;

        private int startingStatValues = 4;
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        protected int luck;


        public Player()
        {
            currentHealth = 100;
            strength = startingStatValues;
            dexterity = startingStatValues;
            intelligence = startingStatValues;
            luck = startingStatValues;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
        }

        // To move
        public void NormalAttack(Enemy targetEnemy)
        {
            targetEnemy.TakeDamage(CalculateDamage());
        }

        // To move
        public int CalculateDamage()
        {
            return Math.Clamp(Helper.CalculateRandomRange(attack), 1, damageCap);
        }

        public void increaseStat()
        {

        }
    }
}
