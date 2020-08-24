// <copyright file="CensusDataAnalyserException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.Exception
{
    using System;

    /// <summary>
    /// Census Analyser Exception.
    /// </summary>
    public class CensusDataAnalyserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDataAnalyserException"/> class.
        /// Exception.
        /// </summary>
        /// <param name="message">Custom message.</param>
        /// <param name="exceptionType">Exception type.</param>
        public CensusDataAnalyserException(string message, ExceptionType exceptionType)
            : base(string.Format(message))
        {
            this.TypeException = exceptionType;
        }

        /// <summary>
        /// Exception Type.
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// Invalid argument.
            /// </summary>
            INVALID_ARGUMENT,

            /// <summary>
            /// File not found.
            /// </summary>
            FILE_NOT_FOUND,

            /// <summary>
            /// Wrong header.
            /// </summary>
            WRONG_HEADER,

            /// <summary>
            /// Invalid file type.
            /// </summary>
            INVALID_FILE_TYPE,

            /// <summary>
            /// Error.
            /// </summary>
            ERROR,
        }

        /// <summary>
        /// Gets or sets type exception.
        /// </summary>
        public ExceptionType TypeException { get; set; }
    }
}
