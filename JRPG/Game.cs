using JRPG.Core;
using JRPG.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG
{
    internal class Game
    {
        private CombatManager combatManager;

        public void Run()
        {
            Console.WriteLine("=== Welcome to MapleJRPG ===");
            StartBattle();
        }

        private void StartBattle()
        {
            Player hero = new Player("Hero");
            Player mage = new Player("Mage");

            Enemy goblin = new Enemy("Goblin");
            Enemy slime = new Enemy("Slime");

            combatManager = new CombatManager();
            combatManager.InitializeCombatants(new Player[] { hero, mage }, new Enemy[] { goblin, slime });

            combatManager.BeginCombat();
        }
    }
}
