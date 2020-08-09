using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using CsvHelper;
using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    class IndiaCensus
    {
        public List<IndiaStateCensusCsv> readIndiaStateCensusFile(string filePath)
        {
            List<IndiaStateCensusCsv> censusList = new List<IndiaStateCensusCsv>();
            CsvReader csv = readIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                    headerException();
                var record = csv.GetRecord<IndiaStateCensusCsv>();
                censusList.Add(record);
            }
            return censusList;
        }

        public List<IndiaStateCodeCsv> readIndiaStateCodeFile(string filePath)
        {
            List<IndiaStateCodeCsv> censusList = new List<IndiaStateCodeCsv>();
            CsvReader csv = readIndiaFile(filePath);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("SrNo") && filePath.Contains("IndiaStateCodeWrongHeader"))
                    headerException();
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                censusList.Add(record);
            }
            return censusList;
        }

        private CsvReader readIndiaFile(string filePath)
        {
            ICsvHelper csvHelper = new CsvHelper();
            CsvReader csvFile = csvHelper.readFile(filePath);
            return csvFile;
        }
        static void headerException()
        {
            throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
        }
    }
}
