using CensusAnalyser.exception;
using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public int readCsvFile(string CSV_FILE_PATH)
        {
            CsvHelper csvHelper = new CsvHelper();
            int numOfRecords = csvHelper.readFile(CSV_FILE_PATH);
            return numOfRecords;
        }
    }
}
