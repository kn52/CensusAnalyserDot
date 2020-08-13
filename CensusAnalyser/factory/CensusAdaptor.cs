using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.poco;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser.factory
{
    abstract class CensusAdaptor
    {
        public abstract Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath);

        public  Dictionary<string, CensusAnalyserDTO> ReadCsvFile(string filePath)
        {
            if (filePath.Contains("WrongHeader"))
                throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);

            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            dynamic record = null;
            CsvReader csv = ReadIndiaFile(filePath);
            
            while (csv.Read())
            {
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
    }
}
