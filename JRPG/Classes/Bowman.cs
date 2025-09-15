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
        static private int maxHealth = 30;
        static private int maxMana = 100;
        static private int attack = 8;
        public Bowman(string name) : base(name, maxHealth, maxMana, attack)
        {
            skillList.Add(new DoubleShot());
            skillList.Add(new ArrowBomb());
        }
    }
}
