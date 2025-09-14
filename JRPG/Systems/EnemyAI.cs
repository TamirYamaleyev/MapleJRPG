using JRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Systems
{
    internal static class EnemyAI
    {
        public static BattleAction AttackRandomPlayer(Enemy enemy)
        {
            Random random = new Random();
            int playerNumber = random.Next(0, CombatManager.players.Count);
            return new BattleAction(enemy, BattleAction.ActionType.Attack, CombatManager.players[playerNumber]);
        }
    }
}
