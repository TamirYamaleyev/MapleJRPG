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
        public Warrior(string name) : base(name)
        {
            maxHealth = 50;
            attack = 4;

            skillList.Add(new PowerStrike());
            skillList.Add(new SlashBlast());
        }
    }
}
