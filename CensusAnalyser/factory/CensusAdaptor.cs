using CensusAnalyser.builder;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using CsvHelper;
using System.Collections.Generic;

namespace CensusAnalyser.factory
{
    abstract class CensusAdaptor
    {
        public abstract Dictionary<string, CensusAnalyserDAO> ReadCensusFile(params string[] filePath);

        public  Dictionary<string, CensusAnalyserDAO> ReadCsvFile(string filePath)
        {
            Dictionary<string, CensusAnalyserDAO> stateCensusList = new Dictionary<string, CensusAnalyserDAO>();
            CsvReader csv = ReadIndiaFile(filePath);
            if (filePath.Contains("IndiaStateCensus"))
            {
                while (csv.Read())
                {
                    if (!csv.Context.Record[0].Contains("State") && filePath.Contains("IndiaStateCensusWrongHeader"))
                        HeaderException();
                    var record = csv.GetRecord<IndiaStateCensusCsv>();
                    stateCensusList.Add(record.state, new CensusAnalyserDAO(record));
                }
            }
            if (filePath.Contains("USCensusData"))
            {
                while (csv.Read())
                {
                    if (!csv.Context.Record[0].Equals("State Id") && filePath.Contains("USCensusWrongHeader"))
                        HeaderException();
                    var record = csv.GetRecord<USCensusCsv>();
                    stateCensusList.Add(record.state, new CensusAnalyserDAO(record));
                }
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
