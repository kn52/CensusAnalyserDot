using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using CsvHelper;
using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    class IndiaCensus
    {
        public Dictionary<string,IndiaStateCensusCsv> ReadIndiaStateCensusFile(string filePath)
        {
            Dictionary<string, IndiaStateCensusCsv> stateCensusList = new Dictionary<string,IndiaStateCensusCsv>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCensusCsv>();
                stateCensusList.Add(record.state,record);
            }
            return stateCensusList;
        }

        public Dictionary<string,IndiaStateCodeCsv> ReadIndiaStateCodeFile(string filePath)
        {
            Dictionary<string, IndiaStateCodeCsv> stateCodeList = new Dictionary<string, IndiaStateCodeCsv>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("SrNo") && filePath.Contains("IndiaStateCodeWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                stateCodeList.Add(record.state,record);
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
