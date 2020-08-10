using CensusAnalyser.exception;
using CsvHelper;
using System.IO;

namespace CensusAnalyser.builder
{
    public class CsvBuilder : ICsvHelper
    {
        public dynamic ReadFile(string filePath)
        {
            CsvReader csvData;
            try
            {
                StreamReader reader = File.OpenText(filePath);
                csvData = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture);
                csvData.Configuration.Delimiter = ",";                
            }
            catch (FileNotFoundException fnfe)
            {
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            
            return csvData;
        }
        
    }
}
