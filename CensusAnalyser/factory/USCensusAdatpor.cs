using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    class USCensusAdatpor : CensusAdaptor
    {
        public override Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath)
        {
            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            stateCensusList = base.ReadCsvFile(filePath[0]);
            return stateCensusList;
        }
    }
}
