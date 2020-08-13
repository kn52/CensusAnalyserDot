using System;

namespace CensusAnalyser.exception
{
    public class CensusDataAnalyserException: Exception
    {
        public enum ExceptionType
        {
            INVALID_ARGUMENT,  FILE_NOT_FOUND, WRONG_HEADER, INVALID_FILE_TYPE, ERROR
        }

        public ExceptionType exceptionType;
        public CensusDataAnalyserException(string message, ExceptionType exceptionType) : base(String.Format(message))
        {
            this.exceptionType = exceptionType;
        }
    }
}
