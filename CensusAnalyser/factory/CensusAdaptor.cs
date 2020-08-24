// <copyright file="CensusAdaptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Factory
{
    using System.Collections.Generic;

    /// <summary>
    /// Census Adaptor.
    /// </summary>
    public abstract class CensusAdaptor
    {
        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="filePath">Csv file path.</param>
        /// <returns>Csv file in a map.</returns>
        public abstract Dictionary<string, CensusAnalyserDTO> ReadCensusFile(params string[] filePath);
    }
}
