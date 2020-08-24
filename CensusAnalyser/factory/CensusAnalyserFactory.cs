// <copyright file="CensusAnalyserFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Factory
{
    using CensusAnalyser.Exception;

    /// <summary>
    /// Census factory.
    /// </summary>
    public class CensusAnalyserFactory
    {
        /// <summary>
        /// Get Csv Helper.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Csv file data.</returns>
        public static dynamic GetCsvHelper(params string[] filePath)
        {
            if (filePath[0].Contains("IndiaStateCensus"))
            {
                return new IndiaCensusAdaptor().ReadCensusFile(filePath);
            }

            if (filePath[0].Contains("USCensus"))
            {
                return new USCensusAdatpor().ReadCensusFile(filePath);
            }

            throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
        }
    }
}
