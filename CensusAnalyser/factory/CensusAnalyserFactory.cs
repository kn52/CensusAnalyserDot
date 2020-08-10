using CensusAnalyser.exception;

namespace CensusAnalyser.factory
{
    public class CensusAnalyserFactory
    {
        public static dynamic GetCsvHelper(params string[] CSV_FILE_PATH)
        {
            if (CSV_FILE_PATH[0].Contains("IndiaStateCensus"))
                return new IndiaCensusAdaptor().ReadCensusFile(CSV_FILE_PATH);
            
            throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
        }
    }
}
