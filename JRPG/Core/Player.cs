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
        public const int damageCap = 999;

        public const float minRangeMultiplier = 0.75f;
        public const float maxRangeMultiplier = 1.25f;

        // <--- Stats --->
        public int MaxHealth { get { return maxHealth; } }
        public int CurrentHealth { get { return currentHealth; } }
        public int MaxMana { get { return maxMana; } }
        public int CurrentMana {  get { return currentMana; } }
        public int Attack {  get { return attack; } }
        public bool IsAlive => CurrentHealth > 0;

        public string Name { get { return name; } }
        protected string name;

        protected int maxHealth = 100;
        protected int currentHealth;
        protected int maxMana = 100;
        protected int currentMana;
        protected int attack = 3;

        private int startingStatValues = 4;
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        protected int luck;


        public Player(string name)
        {
            this.name = name;
            currentHealth = maxHealth;
            currentMana = maxMana;
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

        public int NormalAttack(IDamageable target)
        {
            int damage = CalculateDamage();
            target.TakeDamage(damage);
            return damage;
        }

        // To move?
        public int CalculateDamage()
        {
            return Math.Clamp(Helper.CalculateRandomRange(attack), 1, damageCap);
        }

        public void increaseStat()
        {

        }
    }
}
