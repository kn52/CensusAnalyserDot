using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.poco;
using CsvHelper;
using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    class IndiaCensusAdaptor : CensusAdaptor
    {
        public override Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath)
        {
            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            stateCensusList = base.ReadCsvFile(filePath[0]);
            if (filePath.Length > 1)
                ReadIndiaStateCodeFile(stateCensusList, filePath[1]);
            return stateCensusList;
        }

        public int ReadIndiaStateCodeFile(Dictionary<string, CensusAnalyserDTO> stateCensusList,string filePath)
        {
            if (filePath.Contains("WrongHeader"))
                throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);

            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csv = csvHelper.ReadFile(filePath);
            while (csv.Read())
            {
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                foreach(var rec in stateCensusList)
                {
                    if (rec.Key.Equals(record.state))
                    {
                        rec.Value.stateCode = record.stateCode;
                    }
                }
                
            }
            return stateCensusList.Count;
        }
    }
}
