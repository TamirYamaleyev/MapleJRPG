using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Utils
{
    internal class Helper
    {
        public static int CalculateRandomRange(int value)
        {
            Random random = new Random();
            return random.Next((int)(value * 0.75), (int)(value * 1.25));
        }
    }
}
