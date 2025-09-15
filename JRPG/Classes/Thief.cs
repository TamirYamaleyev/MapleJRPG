using JRPG.Core;
using JRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes
{
    internal class Thief : Player
    {
        static private int maxHealth = 25;
        static private int maxMana = 100;
        static private int attack = 7;
        public Thief(string name) : base(name, maxHealth, maxMana, attack) 
        { 
            skillList.Add(new LuckySeven());
            skillList.Add(new Drain());
        }
    }
}
