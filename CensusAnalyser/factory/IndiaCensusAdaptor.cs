// <copyright file="IndiaCensusAdaptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Factory
{
    using System.Collections.Generic;
    using System.Linq;
    using CensusAnalyser.Builder;
    using CensusAnalyser.Exception;
    using CensusAnalyser.Poco;
    using CsvHelper;

    /// <summary>
    /// India factory.
    /// </summary>
    internal class IndiaCensusAdaptor : CensusAdaptor
    {
        /// <summary>
        /// Read Csv file.
        /// </summary>
        /// <param name="filePath">India csv file path.</param>
        /// <returns>India csv file data.</returns>
        public override Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath)
        {
            if (filePath.Contains("WrongHeader"))
            {
                throw new CensusDataAnalyserException("Wrong Header", CensusDataAnalyserException.ExceptionType.WRONG_HEADER);
            }

            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            CsvReader csv = this.ReadIndiaFile(filePath[0]);
            while (csv.Read())
            {
                var record = csv.GetRecord<IndiaStateCensusCsv>();
                stateCensusList.Add(record.State, new CensusAnalyserDTO(record));
            }

            if (filePath.Length > 1)
            {
                this.ReadIndiaStateCodeFile(stateCensusList, filePath[1]);
            }

            return stateCensusList;
        }

        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="stateCensusList">India census list.</param>
        /// <param name="filePath">India csv file path.</param>
        /// <returns>India Census count.</returns>
        public int ReadIndiaStateCodeFile(Dictionary<string, CensusAnalyserDTO> stateCensusList, string filePath)
        {
            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csv = csvHelper.ReadFile(filePath);
            while (csv.Read())
            {
                var record = csv.GetRecord<IndiaStateCodeCsv>();
                foreach (var rec in stateCensusList)
                {
                    if (rec.Key.Equals(record.State))
                    {
                        rec.Value.StateCode = record.StateCode;
                    }
                }
            }

            return stateCensusList.Count;
        }

        private CsvReader ReadIndiaFile(string filePath)
        {
            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csvFile = csvHelper.ReadFile(filePath);
            return csvFile;
        }
    }
}
