using CensusAnalyser.pojo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    public class IndiaStateCensusComparator : Comparer<IndiaStateCensusCsv>
    {
        public override int Compare(IndiaStateCensusCsv x, IndiaStateCensusCsv y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
