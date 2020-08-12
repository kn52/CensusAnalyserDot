using CensusAnalyser.comparator;
using CensusAnalyser.exception;
using CensusAnalyser.factory;
using CensusAnalyser.pojo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CensusAnalyser.comparator;

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

        public string GetIndiaStateSortedByField(CensusAnalyserComparator.SortByField sortByField, params string[] CSV_FILE_PATH)
        {
            Dictionary<string, CensusAnalyserDAO> csvData = ReadCsvFile(CSV_FILE_PATH);
            CensusAnalyserComparator censusComparator = new CensusAnalyserComparator(sortByField);
            var data = csvData.Select(x => x.Value).ToList();
            data.Sort(censusComparator);
            return JsonConvert.SerializeObject(data);
        }
    }
}
