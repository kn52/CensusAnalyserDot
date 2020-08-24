// <copyright file="USCensusAdatpor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Factory
{
    using System.Collections.Generic;
    using CensusAnalyser.Builder;
    using CensusAnalyser.Poco;
    using CsvHelper;

    /// <summary>
    /// US factory.
    /// </summary>
    internal class USCensusAdatpor : CensusAdaptor
    {
        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="filePath">US csv file path.</param>
        /// <returns>US csv file data.</returns>
        public override Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath)
        {
            Dictionary<string, CensusAnalyserDTO> stateCensusList = new Dictionary<string, CensusAnalyserDTO>();
            ICsvHelper csvHelper = new CsvBuilder();
            CsvReader csv = csvHelper.ReadFile(filePath[0]);

            while (csv.Read())
            {
                var record = csv.GetRecord<USCensusCsv>();
                stateCensusList.Add(record.State, new CensusAnalyserDTO(record));
            }

            return stateCensusList;
        }
    }
}
