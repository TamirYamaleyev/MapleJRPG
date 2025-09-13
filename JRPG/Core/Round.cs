using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal class Round
    {
        private Round() { }
        private static readonly Round _instance = new Round();
        public static Round Instance => _instance;
        public int CurrentRound { get; set; } = 1;
    }
}
