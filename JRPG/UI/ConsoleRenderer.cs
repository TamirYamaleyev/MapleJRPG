using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.UI
{
    internal class ConsoleRenderer
    {
        public static void ShowBattleStatus(List<Player> players, List<Enemy> enemies, int round)
        {
            Console.Clear();
            Console.WriteLine($"--- Round {round} ---\n");

            Console.WriteLine("Players:");
            foreach (var player in players)
                Console.WriteLine($"{player.Name} - HP: {player.CurrentHealth}/{player.MaxHealth}, MP: {player.CurrentMana}/{player.MaxMana}");

            Console.WriteLine("\nEnemies:");
            foreach (var enemy in enemies)
                Console.WriteLine($"{enemy.Name} - HP: {enemy.CurrentHealth}/{enemy.MaxHealth}");

            Console.WriteLine();
        }

        public static void ShowCombatMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("\nChoose Combat Option: \n1) Attack \n2) Skill \n3) Item \n4) Defend \n5) Flee");
        }

        public static void ShowTargets(List<Enemy> enemies)
        {
            Console.WriteLine("Choose a target:");
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{i}) {enemies[i].Name} (HP: {enemies[i].CurrentHealth}/{enemies[i].MaxHealth}");
            }
        }
    }
}
