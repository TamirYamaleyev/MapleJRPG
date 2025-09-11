using JRPG.Core;
using JRPG.Systems;
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


        public static BattleAction DisplayCombatOptions(Player player)
        {
            // Move to UI class
            while (true)
            {
                Console.WriteLine("\nChoose Combat Option: \n1)Attack\n2)Skill\n3)Item\n4)Defend\n5)Flee");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int combatAction))
                {
                    switch (combatAction)
                    {
                        // dont forget to validate if action is possible
                        case 1:
                            return new BattleAction(player, BattleAction.ActionType.Attack, ChooseOneEnemy());
                        case 2: 

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Please enter a valid option.\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number.\n");
                }
            }

        }
        public static Enemy ChooseOneEnemy()
        {
            while (true)
            {
                Console.WriteLine("Choose a target");
                for (int i = 0; i < CombatManager.enemies.Count; i++)
                {
                    Console.WriteLine($"{i}) {CombatManager.enemies[i].Name}");
                }

                string choice = Console.ReadLine();
                int.TryParse(choice, out int pickedEnemy);
                if (pickedEnemy >= 0 && pickedEnemy < CombatManager.enemies.Count)
                {
                    return CombatManager.enemies[pickedEnemy];
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Target. Please enter a valid option.");
                }
            }
        }
    }
}
