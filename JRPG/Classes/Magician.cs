using JRPG.Core;
using JRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes
{
    internal class Magician : Player
    {
        static private int maxHealth = 20;
        static private int maxMana = 100;
        static private int attack = 2;
        public Magician(string name) : base(name, maxHealth, maxMana, attack)
        { 
            skillList.Add(new MagicClaw());
            skillList.Add(new MagicGuard());
            skillList.Add(new PoisonBreath());
            skillList.Add(new ColdBeam());
        }
    }
}
