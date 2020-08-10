using CensusAnalyser.pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    class IndiaStateCodeComparator : Comparer<IndiaStateCodeCsv>
    {
        public override int Compare(IndiaStateCodeCsv x, IndiaStateCodeCsv y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
