using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using CsvHelper;
using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    class IndiaCensus
    {
        public List<IndiaStateCensusCsv> ReadIndiaStateCensusFile(string filePath)
        {
            List<IndiaStateCensusCsv> censusList = new List<IndiaStateCensusCsv>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCensusCsv>();
                censusList.Add(record);
            }
            return censusList;
        }

        public List<IndiaStateCodeCsv> ReadIndiaStateCodeFile(string filePath)
        {
            List<IndiaStateCodeCsv> stateCode = new List<IndiaStateCodeCsv>();
            CsvReader csv = ReadIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("SrNo") && filePath.Contains("IndiaStateCodeWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                stateCode.Add(record);
            }
            return stateCode;
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
