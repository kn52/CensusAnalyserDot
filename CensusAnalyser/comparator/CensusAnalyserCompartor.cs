using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser.comparator
{
    public class CensusAnalyserCompartor : Comparer<CensusAnalyserDAO>
    {
        public override int Compare(CensusAnalyserDAO x, CensusAnalyserDAO y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
