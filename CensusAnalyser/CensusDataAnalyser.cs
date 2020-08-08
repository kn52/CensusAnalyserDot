using CensusAnalyser.exception;
using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusDataAnalyser
    {
        public int ReadCsvFile(string CSV_FILE_PATH)
        {
            string[] csvFileData;
            
            try
            {
                csvFileData = File.ReadAllLines(CSV_FILE_PATH);
                if (!csvFileData[0].Contains("State,Population,AreaInSqKm,DensityPerSqKm") && CSV_FILE_PATH.Contains("IndiaStateCensus"))
                    headerException();
                if(!csvFileData[0].Contains("SrNo,State Name,TIN,StateCode") && CSV_FILE_PATH.Contains("IndiaStateCode"))
                    headerException();
            }
            catch (FileNotFoundException fnfe)
            {
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (ArgumentException ae)
            {
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
            }

            void headerException()
            {
                throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
            }

            return csvFileData.Length - 1;
        }
   }
}
