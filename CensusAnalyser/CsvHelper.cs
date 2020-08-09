using CensusAnalyser.exception;
using CsvHelper;
using System;
using System.IO;

namespace CensusAnalyser
{
    public class CsvHelper : ICsvHelper
    {
        public dynamic readFile(string filePath)
        {
            CsvReader csvData;
            try
            {
                StreamReader reader = File.OpenText(filePath);
                csvData = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture);                
            }
            catch (FileNotFoundException fnfe)
            {
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (ArgumentException ae)
            {
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
            }
            return csvData;
        }
        
    }
}
