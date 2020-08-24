// <copyright file="CensusAnalyserDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser
{
    using CensusAnalyser.Poco;

    /// <summary>
    /// Census Analyser DTO.
    /// </summary>
    public class CensusAnalyserDTO
    {
        /// <summary>
        /// State.
        /// </summary>
        private string state;

        /// <summary>
        /// Population.
        /// </summary>
        private double population;

        /// <summary>
        /// Total Area.
        /// </summary>
        private double totalArea;

        /// <summary>
        /// Total Density.
        /// </summary>
        private double totalDensity;

        /// <summary>
        /// State Code.
        /// </summary>
        private string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserDTO"/> class.
        /// </summary>
        /// <param name="indiaStateCensusCsv">India state object.</param>
        public CensusAnalyserDTO(IndiaStateCensusCsv indiaStateCensusCsv)
        {
            this.State = indiaStateCensusCsv.State;
            this.Population = indiaStateCensusCsv.Population;
            this.TotalArea = indiaStateCensusCsv.AreaInSqKm;
            this.TotalDensity = indiaStateCensusCsv.DensityPerSqKm;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserDTO"/> class.
        /// </summary>
        /// <param name="census">US object.</param>
        public CensusAnalyserDTO(USCensusCsv census)
        {
            this.State = census.State;
            this.StateCode = census.StateCode;
            this.Population = census.Population;
            this.TotalArea = census.TotalArea;
            this.TotalDensity = census.PopulationDensity;
        }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        public string State { get => this.state; set => this.state = value; }

        /// <summary>
        /// Gets or sets population.
        /// </summary>
        public double Population { get => this.population; set => this.population = value; }

        /// <summary>
        /// Gets or sets total area.
        /// </summary>
        public double TotalArea { get => this.totalArea; set => this.totalArea = value; }

        /// <summary>
        /// Gets or sets total density.
        /// </summary>
        public double TotalDensity { get => this.totalDensity; set => this.totalDensity = value; }

        /// <summary>
        /// Gets or sets state code.
        /// </summary>
        public string StateCode { get => this.stateCode; set => this.stateCode = value; }
    }
}
