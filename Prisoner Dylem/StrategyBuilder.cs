using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Strategies;

namespace Prisoner_Dylem
{
    public static class StrategyBuilder
    {
        public static Dictionary<string, Func<int, Strategy>> StrategyBuild = new Dictionary<string, Func<int, Strategy>>
        {
            {"PureChance", chance => new PureChance(chance)}
        };
    }
}
