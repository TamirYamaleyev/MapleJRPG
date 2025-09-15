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
        public Thief(string name) : base(name)
        {
            maxHealth = 25;
            attack = 7;
            skillList.Add(new LuckySeven());
            skillList.Add(new Drain());
        }
    }
}
