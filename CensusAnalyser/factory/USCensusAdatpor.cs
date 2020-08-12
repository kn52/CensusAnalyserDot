using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser.factory
{
    class USCensusAdatpor : CensusAdaptor
    {
        public override Dictionary<string, CensusAnalyserDAO> ReadCensusFile(params string[] filePath)
        {
            Dictionary<string, CensusAnalyserDAO> stateCensusList = new Dictionary<string, CensusAnalyserDAO>();
            stateCensusList = base.ReadCsvFile(filePath[0]);
            return stateCensusList;
        }
    }
}
