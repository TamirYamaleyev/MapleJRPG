using JRPG.Core;
using JRPG.Skills;
using JRPG.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JRPG.Systems
{
    internal class CombatManager
    {
        public static List<Player> players = new List<Player>();
        public static List<Enemy> enemies = new List<Enemy>();
        private List<IDamageable> combatants = new List<IDamageable>();

        public bool battleNotOver = false;
        int currentRound = Round.Instance.CurrentRound;

        public void InitializeCombatants(Player[] playerArray, Enemy[] enemyArray)
        {
            players.Clear();
            enemies.Clear();
            combatants.Clear();

            foreach (Player player in playerArray)
            {
                combatants.Add(player);
                players.Add(player);
            }
            foreach(Enemy enemy in enemyArray)
            {
                combatants.Add(enemy);
                enemies.Add(enemy);
            }
        }

        public void BeginCombat()
        {
            battleNotOver = true;
            while (battleNotOver)
            {
                ConsoleRenderer.ShowBattleStatus(players, enemies, currentRound);

                for (int i = 0; i < combatants.Count; i++)
                {
                    if (CheckBattleOver()) break;

                    if (combatants[i] is Player p)
                    {
                        BattleAction playerAction = InputHandler.DisplayCombatOptions(p, currentRound);
                        ExecuteAction(playerAction);
                        ConsoleRenderer.ShowBattleStatus(players, enemies, currentRound);
                    }
                    else if (combatants[i] is Enemy currentEnemy)
                    {
                        BattleAction enemyAction = EnemyAI.AttackRandomPlayer(currentEnemy);
                        ExecuteAction(enemyAction);
                        ConsoleRenderer.ShowBattleStatus(players, enemies, currentRound);
                    }
                }
                foreach (Player player in players) player.DefendDuration--;
                currentRound++;
            }
        }

        private bool CheckBattleOver()
        {
            if (players.Count == 0)
            {
                CombatLoss();
                return true;
            }
            else if (enemies.Count == 0)
            {
                CombatWin();
                return true;
            }
            return false;
        }

        private void CombatWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleRenderer.ShowCombatMessage("Your party wins the battle!");
            Console.ResetColor();

            foreach (Player player in players)
            {
                player.FullHealthRestore();
                player.FullManaRestore();
            }

            if (Game.currentWave >= Game.finalWave)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ConsoleRenderer.ShowCombatMessage("You have beat the game! Congratulations!");
                Console.ResetColor();
                ShowEndScreen();
                battleNotOver = false;
                return;
            }

            enemies.Clear();
            combatants.Clear();
            combatants.AddRange(players);

            var nextWave = Game.GetNextWave();
            enemies.AddRange(nextWave);
            combatants.AddRange(nextWave);

            currentRound = 0;
        }
        private void CombatLoss()
        {
            battleNotOver = false;
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleRenderer.ShowCombatMessage("Your party has been wiped out...");
            Console.ResetColor();

            ShowEndScreen();
        }

        public void ExecuteAction(BattleAction action)
        {
            switch(action.Type)
            {
                case BattleAction.ActionType.Attack:
                    int damage = action.Actor.NormalAttack(action.Targets[0]);
                    action.ResultValue = damage;
                    break;
                case BattleAction.ActionType.Skill:
                    action.Skill.Use(action.Actor as Player, action.Targets.ToArray());
                    break;
                case BattleAction.ActionType.Defend:
                    Player playerActor = action.Actor as Player;
                    playerActor.DefendDuration = Player.defendActionDurationValue;
                    break;
            }
            ConsoleRenderer.ShowActionResult(action, action.ResultValue);
        }

        public void ShowEndScreen()
        {
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
