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
        public Magician(string name) : base(name)
        {
            maxHealth = 20;
            attack = 2;
            skillList.Add(new MagicClaw());
        }
    }
}
