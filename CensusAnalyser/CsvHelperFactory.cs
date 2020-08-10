using CensusAnalyser.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    class CsvHelperFactory
    {
        public static dynamic getCsvHelper(string CSV_FILE_PATH)
        {
            if (CSV_FILE_PATH.Contains("IndiaStateCode"))
                return new IndiaCensus().readIndiaStateCodeFile(CSV_FILE_PATH);
            if (CSV_FILE_PATH.Contains("IndiaStateCensus"))
                return new IndiaCensus().readIndiaStateCensusFile(CSV_FILE_PATH);
            
            throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
        }
    }
}
