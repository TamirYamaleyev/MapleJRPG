using JRPG.Skills;
using JRPG.Systems;
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
        public const int defendActionDurationValue = 2;
        public const float defendActionValue = 0.5f;

        // <--- Stats --->
        public int MaxHealth { get { return maxHealth; } }
        public int CurrentHealth { get { return currentHealth; } }
        public int MaxMana { get { return maxMana; } }
        public int CurrentMana {  get { return currentMana; } }
        public int Attack {  get { return attack; } }

        public int MagicGuardDuration { get { return magicGuardDuration; } set { magicGuardDuration = value; } }
        public int DefendDuration { get { return defendDuration; } set { defendDuration = value; } }

        public string Name { get { return name; } }
        protected string name;

        protected int maxHealth;
        protected int currentHealth;
        protected int maxMana = 100;
        protected int currentMana;
        protected int attack;

        private int defendDuration = 0;

        public List<Skill> skillList = new List<Skill>();
        private int magicGuardDuration = 0;

        public Player(string name, int maxHealth, int maxMana, int attack)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            FullHealthRestore();
            this.maxMana = maxMana;
            FullManaRestore();
            this.attack = attack;
        }

        public void TakeDamage(int damage)
        {
            if (DefendDuration > 0) damage = (int)(damage * defendActionValue);
            if (magicGuardDuration > 0 && CurrentMana > 0)
            {
                UseMana((int)(damage * MagicGuard.manaSubstituteAmount));
                currentHealth -= (int)(damage * (1 - MagicGuard.manaSubstituteAmount));
                return;
            }
            currentHealth -= damage;

            if (currentHealth <= 0) CombatManager.players.Remove(this);
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
        }
        public void UseMana(int amount)
        {
            currentMana -= amount;
        }

        public int NormalAttack(IDamageable target)
        {
            int damage = CalculateDamage();
            target.TakeDamage(damage);
            return damage;
        }

        public void FullHealthRestore()
        {
            currentHealth = maxHealth;
        }
        public void FullManaRestore()
        {
            currentMana = maxMana;
        }

        public int CalculateDamage()
        {
            return Math.Clamp(Helper.CalculateRandomRange(attack), 1, damageCap);
        }
    }
}
