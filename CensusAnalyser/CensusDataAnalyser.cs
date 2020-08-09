using CensusAnalyser.exception;
using CsvHelper;
using System;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public int readCsvFile(string CSV_FILE_PATH)
        {
            int numOfRecords = 0;
            var data;
            IndiaCensus cen = new IndiaCensus();
            if (CSV_FILE_PATH.Contains("IndiaStateCensus")) 
                 data = cen.readIndiaStateCensusFile(CSV_FILE_PATH);
            if (CSV_FILE_PATH.Contains("IndiaStateCode"))
                data = cen.readIndiaStateCodeFile(CSV_FILE_PATH);
            //while (data.Read())
            //{
            //    numOfRecords++;
            //}
            return data.Length;
        }
    }
}
