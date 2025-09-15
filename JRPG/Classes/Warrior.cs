using JRPG.Core;
using JRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes
{
    internal class Warrior : Player
    {
        static private int maxHealth = 50;
        static private int maxMana = 100;
        static private int attack = 4;
        public Warrior(string name) : base(name, maxHealth, maxMana, attack)
        {
            skillList.Add(new PowerStrike());
            skillList.Add(new SlashBlast());
        }
    }
}
