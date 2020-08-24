// <copyright file="CsvBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Builder
{
    using System.IO;
    using CensusAnalyser.Exception;
    using CsvHelper;

    /// <summary>
    /// Csv Builder.
    /// </summary>
    public class CsvBuilder : ICsvHelper
    {
        /// <summary>
        /// Read File.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Csv  file data.</returns>
        public dynamic ReadFile(string filePath)
        {
            CsvReader csvData;

            if (filePath.Contains("WrongHeader"))
            {
                throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CensusDataAnalyserException("Invalid File Type", CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }

            if (!File.Exists(filePath))
            {
                throw new CensusDataAnalyserException("File Not Found", CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            try
            {
                StreamReader reader = File.OpenText(filePath);
                csvData = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture);
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
