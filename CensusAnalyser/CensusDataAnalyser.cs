using CensusAnalyser.exception;
using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public int loadIndiaCensusData(string CSV_FILE_PATH)
        {
            string[] data;

            if (!CSV_FILE_PATH.Contains(".csv"))
                throw new CensusDataAnalyserException("File Type Error", CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            try
            {
                data = File.ReadAllLines(CSV_FILE_PATH);
                if (!data[0].Contains("State,Population,AreaInSqKm,DensityPerSqKm"))
                    throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
            }
            catch (FileNotFoundException fnfe)
            {
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            return data.Length - 1;

        }
    }
}
