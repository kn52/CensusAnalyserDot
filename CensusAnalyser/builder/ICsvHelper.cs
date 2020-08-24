// <copyright file="ICsvHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Builder
{
    /// <summary>
    /// ICsvHelper.
    /// </summary>
    internal interface ICsvHelper
    {
        /// <summary>
        /// Read File.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Csv file data.</returns>
        dynamic ReadFile(string filePath);
    }
}
