using CensusAnalyser.comparator;
using CensusAnalyser.exception;
using CensusAnalyser.factory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using CensusAnalyser.builder;
using CensusAnalyser.pojo;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public dynamic ReadCsvFile(params string[] CSV_FILE_PATH)
        {
            if (CSV_FILE_PATH.Equals(""))
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);

            var data = CensusAnalyserFactory.GetCsvHelper(CSV_FILE_PATH);
            return data;
        }

        public int GetFileRecordCount(params string[] CSV_FILE_PATH)
        {
            var numOfRecords = ReadCsvFile(CSV_FILE_PATH);
            return numOfRecords.Count;
        }

        public string GetIndiaStateSortedByField(string order,CensusAnalyserComparator.SortByField sortByField, params string[] CSV_FILE_PATH)
        {
            Dictionary<string, CensusAnalyserDAO> csvData = ReadCsvFile(CSV_FILE_PATH);
            CensusAnalyserComparator censusComparator = new CensusAnalyserComparator(sortByField);
            var data = csvData.Select(x => x.Value).ToList();
            data.Sort(censusComparator);
            if (order.Equals("desc"))
            {
                data.Reverse();
            }
            return JsonConvert.SerializeObject(data);
        }

        public int ReadUSFile(string CSV_FILE_PATH)
        {
            List<USCensusCsv> stateCensusList = new List<USCensusCsv>();
            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csv = csvHelper.ReadFile(CSV_FILE_PATH);
            while (csv.Read())
            {
                if (!csv.Context.Record[0].Contains("State") && CSV_FILE_PATH.Contains("IndiaStateCensusWrongHeader"))
                    HeaderException();
                var record = csv.GetRecord<USCensusCsv>();
                stateCensusList.Add(record);
            }
            return stateCensusList.Count;
        }

        static void HeaderException()
        {
            throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
        }
    }
}
