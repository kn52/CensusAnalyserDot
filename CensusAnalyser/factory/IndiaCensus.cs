using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using CsvHelper;

using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    class IndiaCensus
    {
        public Dictionary<string,CensusAnalyserDAO> ReadIndiaStateCensusFile(string filePath)
        {
            Dictionary<string, CensusAnalyserDAO> stateCensusList = new Dictionary<string, CensusAnalyserDAO>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCensusCsv>();
                stateCensusList.Add(record.state,new CensusAnalyserDAO(record));
            }
            return stateCensusList;
        }

        public Dictionary<string,CensusAnalyserDAO> ReadIndiaStateCodeFile(string filePath)
        {
            Dictionary<string, CensusAnalyserDAO> stateCodeList = new Dictionary<string, CensusAnalyserDAO>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("SrNo") && filePath.Contains("IndiaStateCodeWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                stateCodeList.Add(record.state,new CensusAnalyserDAO(record));
            }
            return stateCodeList;
        }

        private CsvReader ReadIndiaFile(string filePath)
        {
            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csvFile = csvHelper.ReadFile(filePath);
            return csvFile;
        }
        static void HeaderException()
        {
            throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
        }
    }
}
