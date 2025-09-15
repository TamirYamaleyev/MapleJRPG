using JRPG.Core;
using JRPG.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JRPG.Skills
{
    internal class SlashBlast : Skill
    {
        private static readonly float damageMultiplier = 0.99f;
        private static readonly int healthCost = 11;
        private static readonly int manaCost = 9;
        private static readonly string displayName = "Slash Blast";
        private static readonly int numOfHits = 1;
        private static readonly string tooltip = "Use HP and MP to attack every enemy around with a sword";
        public SlashBlast() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
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
            foreach (Enemy enemy in CombatManager.enemies)
            {
                enemy.TakeDamage(damage);
            }

            for (int i = 0; i < numOfHits; i++)
                Console.WriteLine($"{caster.Name} uses {Name} on all of the enemies for {damage} damage each!");

            return true;
        }
    }
}
