using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class MagicClaw : Skill
    {
        private static readonly float damageMultiplier = 0.9f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 13;
        private static readonly string displayName = "Magic Claw";
        private static readonly int numOfHits = 2;
        private static readonly string tooltip = "Uses MP to attack an enemy twice";
        public MagicClaw() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
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

            for (int i = 0; i < numOfHits; i++)
                Console.WriteLine($"{caster.Name} uses {Name} on {targets[0].Name} for {damage} damage!");

            return true;
        }
    }
}
