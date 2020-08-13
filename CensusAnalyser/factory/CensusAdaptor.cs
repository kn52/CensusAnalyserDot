﻿using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.poco;
using CsvHelper;
using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    abstract class CensusAdaptor
    {
        public abstract Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath);

        public  Dictionary<string, CensusAnalyserDTO> ReadCsvFile(string filePath)
        {
            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            CsvReader csv = ReadIndiaFile(filePath);
            dynamic record = null;
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                    HeaderException();
                if (filePath.Contains("IndiaStateCensus"))
                {
                    record = csv.GetRecord<IndiaStateCensusCsv>();
                }
                if (filePath.Contains("USCensusData"))
                {
                    record = csv.GetRecord<USCensusCsv>();
                }

                stateCensusList.Add(record.state, new CensusAnalyserDTO(record));
            }
            
            

            return stateCensusList;
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
