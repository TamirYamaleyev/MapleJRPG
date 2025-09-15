using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class Drain : Skill
    {
        private static readonly float damageMultiplier = 1.2f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 10;
        private static readonly string displayName = "Drain";
        private static readonly int numOfHits = 1;
        private static readonly string tooltip = "Absorb some of the damage dished out to the enemy as HP";

        private static readonly float lifeStealPercentage = 0.25f;
        public Drain() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
        {
        }

        public override bool Use(Player caster, IDamageable[] targets)
        {
            if (caster.CurrentMana < ManaCost)
            {
                Console.WriteLine($"{caster.Name} does not have enough MP to use {Name}");
                return false;
            }

            caster.UseMana(ManaCost);

            int damage = (int)(caster.Attack * damageMultiplier);
            targets[0].TakeDamage(damage * numOfHits);

            caster.Heal((int)(damage * lifeStealPercentage));

            Console.WriteLine($"{caster.Name} uses {Name} on {targets[0].Name} for {damage} damage!");

            return true;
        }
    }
}
