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
        public static void ShowActionResult(BattleAction action, int resultValue)
        {
            switch (action.Type)
            {
                case BattleAction.ActionType.Attack:
                    Console.WriteLine($"{action.Actor.Name} attacks {action.Targets[0].Name} for {resultValue} damage");
                    break;
                case BattleAction.ActionType.Skill:
                    Console.WriteLine($"PLACEHOLDER");
                    break;
                case BattleAction.ActionType.Item:
                    Console.WriteLine($"PLACEHOLDER");
                    break;
                case BattleAction.ActionType.Defend:
                    Console.WriteLine($"{action.Actor} Defends");
                    break;
            }
        }
    }
}
