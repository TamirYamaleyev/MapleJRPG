using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal abstract class Skill
    {
        public string Name { get; set; }
        public int HealthCost { get; set; }
        public int ManaCost { get; set; }
        public int NumOfHits { get; set; }
        public string Tooltip { get; set; }

        protected Skill(string name, int healthCost, int manaCost, int numOfHits, string tooltip)
        {
            Name = name;
            HealthCost = healthCost;
            ManaCost = manaCost;
            NumOfHits = numOfHits;
            Tooltip = tooltip;
        }

        public abstract bool Use(Player caster, IDamageable[] targets);
    }
}
