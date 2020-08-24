// <copyright file="USCensusCsv.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Poco
{
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// US census poco class.
    /// </summary>
    public class USCensusCsv
    {
        /// <summary>
        /// Gets or sets state id.
        /// </summary>
        [Name("State Id")]
        public string StateCode { get; set; }

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
        /// Gets or sets housing units.
        /// </summary>
        [Name("Housing units")]
        public double HousingUnits { get; set; }

        /// <summary>
        /// Gets or sets total area.
        /// </summary>
        [Name("Total area")]
        public double TotalArea { get; set; }

        /// <summary>
        /// Gets or sets water area.
        /// </summary>
        [Name("Water area")]
        public double WaterArea { get; set; }

        /// <summary>
        /// Gets or sets land Area.
        /// </summary>
        [Name("Land area")]
        public double LandArea { get; set; }

        /// <summary>
        /// Gets or sets population density.
        /// </summary>
        [Name("Population Density")]
        public double PopulationDensity { get; set; }

        /// <summary>
        /// Gets or sets housing density.
        /// </summary>
        [Name("Housing Density")]
        public double HousingDensity { get; set; }
    }
}