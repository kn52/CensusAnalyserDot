using CensusAnalyser.comparator;
using CensusAnalyser.exception;
using Newtonsoft.Json;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public dynamic readCsvFile(string CSV_FILE_PATH)
        {
            if (CSV_FILE_PATH.Equals(""))
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);

            var data = CsvHelperFactory.getCsvHelper(CSV_FILE_PATH);
            return data;
        }

        public int getFileRecordCount(string CSV_FILE_PATH)
        {
            var numOfRecords = readCsvFile(CSV_FILE_PATH);
            return numOfRecords.Count;
        }

        public string getIndiaCensusSortedByName(string CSV_FILE_PATH)
        {
            var csvData = readCsvFile(CSV_FILE_PATH);
            IndiaStateCensusComparator censusComparator = new IndiaStateCensusComparator();
            csvData.Sort(censusComparator);
            return JsonConvert.SerializeObject(csvData);
        }

        public string getIndiaStateCensusSortedByName(string CSV_FILE_PATH)
        {
            var csvData = readCsvFile(CSV_FILE_PATH);
            IndiaStateCensusComparator censusComparator = new IndiaStateCensusComparator();
            csvData.Sort(censusComparator);
            return JsonConvert.SerializeObject(csvData);
        }

        public string getIndiaStateCodeSortedByName(string CSV_FILE_PATH)
        {
            var csvData = readCsvFile(CSV_FILE_PATH);
            IndiaStateCodeComparator censusComparator = new IndiaStateCodeComparator();
            csvData.Sort(censusComparator);
            return JsonConvert.SerializeObject(csvData);
        }
    }
}
