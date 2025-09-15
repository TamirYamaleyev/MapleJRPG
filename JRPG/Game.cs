using JRPG.Classes;
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
            Player warrior = new Warrior("Swordsman");
            Player bowman = new Bowman("Archer");
            Player magician = new Magician("Magician");
            Player thief = new Thief("Rogue");

            Enemy goblin = new Enemy("Goblin");
            Enemy slime = new Enemy("Slime");
            Enemy skeleton = new Enemy("Skeleton");
            Enemy zombie = new Enemy("Zombie");

            combatManager = new CombatManager();
            combatManager.InitializeCombatants(new Player[] { warrior, bowman, magician, thief }, new Enemy[] { goblin, slime, skeleton, zombie });

            combatManager.BeginCombat();
        }
    }
}
