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
    }
}
