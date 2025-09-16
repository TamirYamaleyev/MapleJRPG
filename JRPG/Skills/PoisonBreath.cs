using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JRPG.Skills
{
    internal class PoisonBreath : Skill
    {
        private static readonly float damageMultiplier = 1.3f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 10;
        private static readonly string displayName = "Poison Breath";
        private static readonly int numOfHits = 1;
        private static readonly string tooltip = $"Creates a poisonous water bubble and shoots at an enemy. The enemy gets temporarily poisoned for {duration} turns";

        private static readonly float poisonDamageMultiplier = 1.3f;
        public static readonly int duration = 2;
        public PoisonBreath() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
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
            target.PoisonDuration = duration;
            target.PoisonDamage = (int)(damage * poisonDamageMultiplier);

            Console.WriteLine($"{caster.Name} uses {Name} on {targets[0].Name} for {damage} damage! {targets[0].Name} is now Poisoned for {duration} turns!");

            return true;
        }
    }
}
