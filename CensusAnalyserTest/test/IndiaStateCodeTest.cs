﻿using NUnit.Framework;
using CensusAnalyser;
using CensusAnalyser.pojo;
using CensusAnalyser.exception;
using Newtonsoft.Json;

namespace CensusAnalyserTest
{
    class IndiaStateCodeTest
    {
        static string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
        private readonly string INDIA_STATECODE_FILE_PATH = testPath + "csvfiles\\IndiaStateCode.csv";
        private readonly string INDIA_STATECODE_FILE_WRONG_PATH = testPath + "IndiaStateCode.csv";
        private readonly string INDIA_STATECODE_WRONG_TYPE_FILE_PATH = testPath + "csvfiles\\IndiaStateCode.type";
        private readonly string INDIA_STATECODE_WRONG_HEADER_FILE_PATH = testPath + "csvfiles\\IndiaStateCodeWrongHeader.csv";

        CensusDataAnalyser censusDataAnalyser;

        [SetUp]
        public void Setup()
        {
            censusDataAnalyser = new CensusDataAnalyser();
        }

        [Test]
        public void GivenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int count = censusDataAnalyser.GetFileRecordCount(INDIA_STATECODE_FILE_PATH);
            Assert.AreEqual(37, count);
        }

        [Test]
        public void GivenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_STATECODE_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void GivenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_STATECODE_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.exceptionType);
        }


        [Test]
        public void GivenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_STATECODE_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.exceptionType);
        }

        [Test]
        public void GivenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT, ex.exceptionType);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnName_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateCodeSortedByName(INDIA_STATECODE_FILE_PATH);
            IndiaStateCodeCsv[] indiaStateCodeCsv = JsonConvert.DeserializeObject<IndiaStateCodeCsv[]>(json);
            Assert.AreEqual("Andaman and Nicobar Islands", indiaStateCodeCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnName_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateCodeSortedByName(INDIA_STATECODE_FILE_PATH);
            IndiaStateCodeCsv[] indiaStateCodeCsv = JsonConvert.DeserializeObject<IndiaStateCodeCsv[]>(json);
            Assert.AreEqual("West Bengal", indiaStateCodeCsv[indiaStateCodeCsv.Length - 1].state);
        }
    }
    
}
