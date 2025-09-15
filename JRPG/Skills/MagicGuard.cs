using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JRPG.Skills
{
    internal class MagicGuard : Skill
    {
        private static readonly float damageMultiplier = 0f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 8;
        private static readonly string displayName = "Magic Guard";
        private static readonly int numOfHits = 0;

        private static readonly int duration = 3;
        public static readonly float manaSubstituteAmount = 0.42f;
        public MagicGuard() : base(displayName, healthCost, manaCost, numOfHits)
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

            caster.MagicGuardDuration = duration;
            Console.WriteLine($"{caster.Name} uses {Name}");

            return true;
        }
    }
}
