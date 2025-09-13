using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Utils
{
    internal class Helper
    {
        private static float minRangeMultiplier = 0.75f;
        private static float maxRangeMultiplier = 1.25f;
        public static int CalculateRandomRange(int value)
        {
            Random random = new Random();
            return random.Next((int)(value * minRangeMultiplier), (int)(value * maxRangeMultiplier));
        }

        public static int ChoiceSelection(string prompt, string[] options, string[]? tooltips = null)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            int menuTop = Console.WindowHeight - options.Length - 5;

            do
            {
                Console.SetCursorPosition(0, menuTop);
                Console.WriteLine(prompt.PadRight(Console.WindowWidth));
                Console.WriteLine(new string(' ', Console.WindowWidth));

                // Display menu options
                for (int i = 0; i < options.Length; i++)
                {
                    string line = (i == selectedIndex ? $"> {options[i]}" : $"  {options[i]}").PadRight(Console.WindowWidth);
                    Console.ForegroundColor = i == selectedIndex ? ConsoleColor.Green : Console.ForegroundColor;
                    Console.WriteLine(line);
                    Console.ResetColor();
                }

                // Display tooltip if available, padded to console width
                string tooltip = "";
                if (tooltips != null && selectedIndex < tooltips.Length && !string.IsNullOrWhiteSpace(tooltips[selectedIndex]))
                    tooltip = tooltips[selectedIndex];

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(tooltip.PadRight(Console.WindowWidth));
                Console.ResetColor();

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % options.Length;

                // Move cursor back to top of menu for next redraw
                Console.SetCursorPosition(0, menuTop);

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }


    }
}
