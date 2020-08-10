using CensusAnalyser.comparator;
using CensusAnalyser.exception;
using CensusAnalyser.factory;
using CensusAnalyser.pojo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public dynamic ReadCsvFile(string CSV_FILE_PATH)
        {
            if (CSV_FILE_PATH.Equals(""))
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);

            var data = CsvHelperFactory.GetCsvHelper(CSV_FILE_PATH);
            return data;
        }

        public int GetFileRecordCount(string CSV_FILE_PATH)
        {
            var numOfRecords = ReadCsvFile(CSV_FILE_PATH);
            return numOfRecords.Count;
        }

        public string GetIndiaCensusSortedByName(string CSV_FILE_PATH)
        {
            var csvData = ReadCsvFile(CSV_FILE_PATH);
            IndiaStateCensusComparator censusComparator = new IndiaStateCensusComparator();
            csvData.Sort(censusComparator);
            return JsonConvert.SerializeObject(csvData);
        }

        public string GetIndiaStateCensusSortedByName(string CSV_FILE_PATH)
        {
            Dictionary<string, IndiaStateCensusCsv> csvData = ReadCsvFile(CSV_FILE_PATH);
            IndiaStateCensusComparator censusComparator = new IndiaStateCensusComparator();
            var data = csvData.Select(x => x.Value).ToList();
            data.Sort(censusComparator);
            return JsonConvert.SerializeObject(data);
        }

        public string GetIndiaStateCodeSortedByName(string CSV_FILE_PATH)
        {
            Dictionary<string, IndiaStateCodeCsv> csvData = ReadCsvFile(CSV_FILE_PATH);
            IndiaStateCodeComparator censusComparator = new IndiaStateCodeComparator();
            var data = csvData.Select(x => x.Value).ToList();
            data.Sort(censusComparator);
            return JsonConvert.SerializeObject(data);
        }
    }
}
