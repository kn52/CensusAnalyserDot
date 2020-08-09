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
            ICsvHelper csvHelper = new CsvHelper();
            CsvReader data = csvHelper.readFile(CSV_FILE_PATH);
            while (data.Read())
            {
                if (!data.Context.Record[0].Contains("State") && CSV_FILE_PATH.Contains("IndiaStateCensusWrongHeader"))
                    headerException();
                if (!data.Context.Record[0].Contains("SrNo") && CSV_FILE_PATH.Contains("IndiaStateCodeWrongHeader"))
                    headerException();
                numOfRecords++;
            }
            return --numOfRecords;
        }

        static void headerException()
        {
            throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
        }

    }
}
