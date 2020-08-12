﻿using CensusAnalyser;
using CensusAnalyser.comparator;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CensusAnalyserTest.test
{
    class USCensusTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest";
        private readonly string US_CENSUS_FILE_PATH = testPath + "\\csvfiles\\USCensusData.csv";
        private readonly string US_CENSUS_FILE_WRONG_PATH = testPath + "USCensusData.csv";

        CensusDataAnalyser censusDataAnalyser;

        [SetUp]
        public void Setup()
        {
            censusDataAnalyser = new CensusDataAnalyser();
        }

        [Test]
        public void GivenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int count = censusDataAnalyser.GetFileRecordCount(US_CENSUS_FILE_PATH);
            Assert.AreEqual(51, count);
        }

        [Test]
        public void GivenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(US_CENSUS_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnState_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Alabama", uSCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnState_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Wyoming", uSCensusCsv[uSCensusCsv.Length - 1].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.POPULATION, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("California", uSCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.POPULATION, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Wyoming", uSCensusCsv[uSCensusCsv.Length - 1].state);
        }
    }
}
