using JRPG.Core;
using JRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes
{
    internal class Bowman : Player
    {
        public Bowman(string name) : base(name)
        {
            maxHealth = 30;
            attack = 8;
            skillList.Add(new DoubleShot());
        }
    }
}
