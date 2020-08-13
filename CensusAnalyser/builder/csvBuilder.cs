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
            if (Path.GetExtension(filePath) != ".csv")
                throw new CensusDataAnalyserException("Invalid File Type", CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            if (!File.Exists(filePath))
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);

            try
            {
                StreamReader reader = File.OpenText(filePath);
                csvData = new CsvReader(reader,System.Globalization.CultureInfo.CurrentCulture);
                csvData.Configuration.Delimiter = ",";                
            }
            catch (CensusDataAnalyserException cdae)
            {
                throw new CensusDataAnalyserException(cdae.Message, CensusDataAnalyserException.ExceptionType.ERROR);
            }
            
            return csvData;
        }
        
    }
}
