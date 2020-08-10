using CensusAnalyser.pojo;
using System.Collections.Generic;

namespace CensusAnalyser.comparator
{
    class IndiaStateCodeComparator : Comparer<IndiaStateCodeCsv>
    {
        public override int Compare(IndiaStateCodeCsv x, IndiaStateCodeCsv y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
