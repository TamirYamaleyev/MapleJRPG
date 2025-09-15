using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class ColdBeam : Skill
    {
        private static readonly float damageMultiplier = 1.4f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 12;
        private static readonly string displayName = "Cold Beam";
        private static readonly int numOfHits = 1;

        public static readonly int duration = 2;
        public ColdBeam() : base(displayName, healthCost, manaCost, numOfHits)
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

            Enemy target = targets[0] as Enemy;
            target.StunDuration = duration;

            Console.WriteLine($"{caster.Name} uses {Name} on {targets[0].Name} for {damage} damage! {targets[0].Name} is now Stunned for {duration} turns!");

            return true;
        }
    }
}
