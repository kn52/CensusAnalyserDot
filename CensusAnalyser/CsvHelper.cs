using CensusAnalyser.exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CsvHelper : ICsvHelper
    {
        static void headerException()
        {
            throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
        }

        public int readFile(string filePath)
        {
            string[] csvData=null;
            try
            {
                csvData = File.ReadAllLines(filePath);
                if (!csvData[0].Contains("State,Population,AreaInSqKm,DensityPerSqKm") && filePath.Contains("IndiaStateCensus"))
                    headerException();
                if (!csvData[0].Contains("SrNo,State Name,TIN,StateCode") && filePath.Contains("IndiaStateCode"))
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
            return csvData.Length-1;
        }
        
    }
}
