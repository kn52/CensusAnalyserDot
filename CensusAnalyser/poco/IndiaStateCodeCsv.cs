// <copyright file="IndiaStateCodeCsv.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Poco
{
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// India state code poco class.
    /// </summary>
    public class IndiaStateCodeCsv
    {
        /// <summary>
        /// Gets or sets serial number.
        /// </summary>
        [Name("SrNo")]
        public int SrNo { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [Name("State Name")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets pin.
        /// </summary>
        [Name("TIN")]
        public int Pin { get; set; }

        /// <summary>
        /// Gets or sets state code.
        /// </summary>
        [Name("StateCode")]
        public string StateCode { get; set; }
    }
}
