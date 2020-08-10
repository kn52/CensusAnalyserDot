using CensusAnalyser.pojo;
using System.Collections.Generic;

namespace CensusAnalyser.comparator
{
    public class IndiaStateCensusComparator : Comparer<IndiaStateCensusCsv>
    {
        public override int Compare(IndiaStateCensusCsv x, IndiaStateCensusCsv y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
