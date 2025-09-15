using JRPG.Core;
using JRPG.Skills;
using JRPG.Systems;
using JRPG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.UI
{
    internal class InputHandler
    {
        
        //public Skill? ChosenSkill { get; set; }
        //public Item? ChosenItem { get; set; }


        public static BattleAction DisplayCombatOptions(Player player, int currentRound)
        {
            string[] options = { "Attack", "Skill", "Item", "Defend" };
            string[] tooltips = { $"Attack Range: {Math.Floor(player.Attack * Player.minRangeMultiplier)} ~ {Math.Ceiling(player.Attack * Player.maxRangeMultiplier)}", "(Class Skills)", "(Potions, etc)", "Take half damage for a turn" };
            int choice = Helper.ChoiceSelection($"{player.Name}, choose your action:", options, tooltips);

            switch (choice)
            {
                case 0:
                    ConsoleRenderer.ShowBattleStatus(CombatManager.players, CombatManager.enemies, Round.Instance.CurrentRound);
                    return new BattleAction(player, BattleAction.ActionType.Attack, ChooseOneEnemy());
                case 1:
                    Skill chosenSkill = ChooseASkill(player);
                    if (chosenSkill is MagicGuard && chosenSkill is SlashBlast)
                    {
                        Enemy chosenEnemy = ChooseOneEnemy();
                        return new BattleAction(player, chosenSkill, chosenEnemy);
                    }
                    return new BattleAction(player, chosenSkill);
                case 2:
                    return new BattleAction(player, BattleAction.ActionType.Item);
                case 3:
                    return new BattleAction(player, BattleAction.ActionType.Defend);
            }

            // Fallback in case of bug?
            return new BattleAction(player, BattleAction.ActionType.Defend);
        }
        public static Enemy ChooseOneEnemy()
        {
            string[] enemyNames = CombatManager.enemies.Select(e => $"{e.Name} (HP: {e.CurrentHealth}/{e.MaxHealth})").ToArray();
            int choice = Helper.ChoiceSelection("Choose a target:", enemyNames);
            return CombatManager.enemies[choice];
        }

        public static Skill ChooseASkill(Player actor)
        {
            string[] skillNames = actor.skillList.Select(s => $"{s.Name} (HP Cost: {s.HealthCost} | MP Cost: {s.ManaCost})").ToArray();
            int choice = Helper.ChoiceSelection("Choose a skill:", skillNames);
            return actor.skillList[choice];
        }
    }
}
