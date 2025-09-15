using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class PowerStrike : Skill
    {
        private static readonly float damageMultiplier = 2.1f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 7;
        private static readonly string displayName = "Power Strike";
        private static readonly int numOfHits = 1;
        private static readonly string tooltip = "Use MP to deliver a killer blow to the monsters with a sword";
        public PowerStrike() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
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
            targets[0].TakeDamage(damage);

            Console.WriteLine($"{caster.Name} uses {Name} on {targets[0].Name} for {damage} damage!");

            return true;
        }
    }
}
