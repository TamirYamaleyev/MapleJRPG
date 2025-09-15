using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class LuckySeven : Skill
    {
        private static readonly float damageMultiplier = 1f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 11;
        private static readonly string displayName = "Lucky Seven";
        private static readonly int numOfHits = 2;
        public LuckySeven() : base(displayName, healthCost, manaCost, numOfHits)
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
