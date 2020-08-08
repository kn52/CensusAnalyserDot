using System;

namespace CensusAnalyser.exception
{
    public class CensusDataAnalyserException: Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, WRONG_HEADER
        }
        public ExceptionType exceptionType;
        public CensusDataAnalyserException(string message, ExceptionType exceptionType) : base(String.Format(message))
        {
            this.exceptionType = exceptionType;
        }
    }
}
