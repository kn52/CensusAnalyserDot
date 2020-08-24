// <copyright file="IndiaStateCensusCsv.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Poco
{
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// India state census poco class.
    /// </summary>
    public class IndiaStateCensusCsv
    {
        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [Name("State")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets population.
        /// </summary>
        [Name("Population")]
        public double Population { get; set; }

        /// <summary>
        /// Gets or sets area.
        /// </summary>
        [Name("AreaInSqKm")]
        public double AreaInSqKm { get; set; }

        /// <summary>
        /// Gets or sets density.
        /// </summary>
        [Name("DensityPerSqKm")]
        public double DensityPerSqKm { get; set; }
    }
}