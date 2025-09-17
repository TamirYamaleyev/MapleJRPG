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
        private AudioManager audioManager;

        public static int currentWave = 1;
        public static int finalWave = 4;

        static Enemy snail = new Enemy("Snail", 1);
        static Enemy slime = new Enemy("Slime", 2);
        static Enemy mushroom = new Enemy("Mushroom", 2);
        static Enemy ribbonPig = new Enemy("Ribbon Pig", 3);
        static Enemy stirge = new Enemy("Stirge", 3);
        static Enemy darkStump = new Enemy("Dark Stump", 3);
        static Enemy axeStump = new Enemy("Axe Stump", 4);
        static Enemy wildBoar = new Enemy("Wild Board", 5);
        static Enemy ligator = new Enemy("Ligator", 5);
        static Enemy fireBoar = new Enemy("Fire Boar", 6);
        static Enemy woodenMask = new Enemy("Wooden Mask", 6);
        static Enemy skeledog = new Enemy("Skeledog", 10);
        static Enemy mummydog = new Enemy("Mummydog", 11);
        static Enemy croco = new Enemy("Croco", 13);
        static Enemy evilEye = new Enemy("Evil Eye", 13);
        static Enemy coldEye = new Enemy("Cold Eye", 13);
        static Enemy golem = new Enemy("Golem", 16);
        static Enemy darkGolem = new Enemy("Dark Golem", 17);
        static Enemy mixedGolem = new Enemy("Mixed Golem", 17);

        static Enemy mushmomBoss = new Enemy("Mushmom", 20);

        private static Enemy[] firstWaveEnemies = new Enemy[] { snail, slime, mushroom, ribbonPig };
        private static Enemy[] secondWaveEnemies = new Enemy[] {mummydog, darkStump, axeStump, wildBoar };
        private static Enemy[] thirdWaveEnemies = new Enemy[] { golem, coldEye, evilEye };
        private static Enemy[] bossWave = new Enemy[] { mushmomBoss };

        public void Run()
        {
            audioManager = new AudioManager();
            audioManager.PlayBGM("HenesysBGM.mp3");

            Console.WriteLine("=== Welcome to MapleJRPG ===");
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            StartBattle();
        }

        private void StartBattle()
        {
            Player warrior = new Warrior("Swordsman");
            Player bowman = new Bowman("Archer");
            Player magician = new Magician("Magician");
            Player thief = new Thief("Rogue");

            combatManager = new CombatManager(audioManager);

            combatManager.InitializeCombatants(new Player[] { warrior, bowman, magician, thief }, firstWaveEnemies);
            combatManager.BeginCombat();
        }

        public static Enemy[] GetNextWave()
        {
            currentWave++;
            switch (currentWave)
            {
                case 1:
                    return firstWaveEnemies;
                case 2:
                    return secondWaveEnemies;
                case 3:
                    return thirdWaveEnemies;
                case 4:
                    return bossWave;
                default: return bossWave;
            }
        }
    }
}
