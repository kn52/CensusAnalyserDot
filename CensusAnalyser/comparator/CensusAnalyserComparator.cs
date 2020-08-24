// <copyright file="CensusAnalyserComparator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Comparator
{
    using System.Collections.Generic;

    /// <summary>
    /// Comparator class.
    /// </summary>
    public class CensusAnalyserComparator : Comparer<CensusAnalyserDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserComparator"/> class.
        /// </summary>
        /// <param name="sortByField">Sort field name.</param>
        public CensusAnalyserComparator(SortByField sortByField)
        {
            this.CompareByField = sortByField;
        }

        /// <summary>
        /// Enum sort by field.
        /// </summary>
        public enum SortByField
        {
            /// <summary>
            /// Sort by state.
            /// </summary>
            STATE,

            /// <summary>
            /// Sort by state code.
            /// </summary>
            STATE_CODE,

            /// <summary>
            /// Sort by population.
            /// </summary>
            POPULATION,

            /// <summary>
            /// Sort by density.
            /// </summary>
            DENSITY,

            /// <summary>
            /// Sort by area.
            /// </summary>
            AREA,
        }

        /// <summary>
        /// Gets or sets compare field.
        /// </summary>
        public SortByField CompareByField { get; set; }

        /// <summary>
        /// Compare method.
        /// </summary>
        /// <param name="x">DTO first object.</param>
        /// <param name="y">DTO second object.</param>
        /// <returns>Compare condition.</returns>
        public override int Compare(CensusAnalyserDTO x, CensusAnalyserDTO y)
        {
            switch (this.CompareByField)
            {
                case SortByField.STATE:
                    return x.State.CompareTo(y.State);
                case SortByField.STATE_CODE:
                    return x.StateCode.CompareTo(y.StateCode);
                case SortByField.POPULATION:
                    return x.Population.CompareTo(y.Population);
                case SortByField.DENSITY:
                    return x.TotalDensity.CompareTo(y.TotalDensity);
                case SortByField.AREA:
                    return x.TotalArea.CompareTo(y.TotalArea);
                default:
                    break;
            }

            return x.State.CompareTo(y.State);
        }
    }
}
