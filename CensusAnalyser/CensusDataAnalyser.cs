// <copyright file="CensusDataAnalyser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser
{
    using System.Collections.Generic;
    using System.Linq;
    using CensusAnalyser.Comparator;
    using CensusAnalyser.Exception;
    using CensusAnalyser.Factory;
    using CensusAnalyser.Poco;
    using Newtonsoft.Json;

    /// <summary>
    /// Census Analyser class.
    /// </summary>
    public class CensusDataAnalyser
    {
        /// <summary>
        /// Read a csv file.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Csv file data.</returns>
        public dynamic ReadCsvFile(params string[] filePath)
        {
            if (filePath.Equals(string.Empty))
            {
                throw new CensusDataAnalyserException("Invalid Argument", CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT);
            }

            var data = CensusAnalyserFactory.GetCsvHelper(filePath);
            return data;
        }

        /// <summary>
        /// Get file count.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Number of records in a file.</returns>
        public int GetFileRecordCount(params string[] filePath)
        {
            var numOfRecords = this.ReadCsvFile(filePath);
            return numOfRecords.Count;
        }

        /// <summary>
        /// Get India state sorted record.
        /// </summary>
        /// <param name="order">Order by.</param>
        /// <param name="sortByField">Sort file record by.</param>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Sorted record by field.</returns>
        public string GetIndiaStateSortedByField(string order, CensusAnalyserComparator.SortByField sortByField, params string[] filePath)
        {
            Dictionary<string, CensusAnalyserDTO> csvData = this.ReadCsvFile(filePath);
            CensusAnalyserComparator censusComparator = new CensusAnalyserComparator(sortByField);
            var data = csvData.Select(x => x.Value).ToList();
            data.Sort(censusComparator);
            if (order.Equals("desc"))
            {
                data.Reverse();
            }

            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Get populated state.
        /// </summary>
        /// <param name="indiaStateCensusCsv"> India state object.</param>
        /// <param name="usCensusCsv">US object.</param>
        /// <returns>Most populated state among them.</returns>
        public string GetIndiaUSMostPopulatedState(IndiaStateCensusCsv indiaStateCensusCsv, USCensusCsv usCensusCsv)
        {
            string state = (indiaStateCensusCsv.DensityPerSqKm > usCensusCsv.PopulationDensity)
                ? indiaStateCensusCsv.State : usCensusCsv.State;

            return state;
        }
    }
}
