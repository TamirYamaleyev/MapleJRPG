using JRPG.Classes;
using JRPG.Core;
using JRPG.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Skills
{
    internal class ArrowBomb : Skill
    {
        private static readonly float damageMultiplier = 0.96f;
        private static readonly int healthCost = 0;
        private static readonly int manaCost = 14;
        private static readonly string displayName = "Arrow Bomb";
        private static readonly int numOfHits = 1;
        private static readonly string tooltip = "Fires an arrow with a bomb attached to it. the bomb explodes on the enemy, dealing damage to all enemies around it";
        public ArrowBomb() : base(displayName, healthCost, manaCost, numOfHits, tooltip)
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

            // Normal arrow shot damage at target
            targets[0].TakeDamage(caster.Attack);

            // Explosion damage to all nearby enemies
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
