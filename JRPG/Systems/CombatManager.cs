using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Systems
{
    internal class CombatManager
    {
        List<Player> players = new List<Player>();
        List<Enemy> enemies = new List<Enemy>();
        List<IDamageable> combatants = new List<IDamageable>();

        public bool battleNotOver = false;
        public int currentRound = 1;

        public void InitializeCombatants(Player[] playerArray, Enemy[] enemyArray)
        {
            foreach(Player player in playerArray)
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
                for (int i = combatants.Count - 1; i >= 0; i--)
                {
                    if (!combatants[i].IsAlive)
                    {
                        RemoveCombatant(combatants[i]);
                        if (CheckBattleOver()) break;
                        continue;
                    }

                    if (combatants[i] is Player)
                    {
                        // Call UI for Player turn
                    }
                    else if (combatants[i] is Enemy)
                    {
                        // Call AI for Enemy Turn
                    }
                }
                currentRound++;
            }
        }

        private void RemoveCombatant(IDamageable combatant)
        {
            if (combatant is Player p) players.Remove(p);
            else if (combatant is Enemy e) enemies.Remove(e);

            combatants.Remove(combatant);
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
            battleNotOver = false;
            Console.WriteLine("Your party wins the battle!");
        }
        private void CombatLoss()
        {
            battleNotOver = false;
            Console.WriteLine("Your party has been wiped out...");
        }
    }
}
