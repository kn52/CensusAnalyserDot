using CensusAnalyser;
using CensusAnalyser.comparator;
using CensusAnalyser.poco;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CensusAnalyserTest.test
{
    class CensusTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
        private readonly string INDIA_CENSUS_FILE_PATH = testPath + "csvfiles\\IndiaStateCensusData.csv";
        private readonly string US_CENSUS_FILE_PATH = testPath + "csvfiles\\USCensusData.csv";

        CensusDataAnalyser censusDataAnalyser;

        [SetUp]
        public void Setup()
        {
            censusDataAnalyser = new CensusDataAnalyser();
        }

        [Test]
        public void GivenCSVFilePaths_WhenCorrect_willReturnJsonFile()
        {
            string indiaJson = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.AREA, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(indiaJson);
            string usJson = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE, US_CENSUS_FILE_PATH);
            USCensusCsv[] usCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(usJson);
            string mostPopulatedState= censusDataAnalyser.GetIndiaUSMostPopulatedState(indiaStateCensusCsv[0], usCensusCsv[0]);
            Assert.AreEqual("Alabama", mostPopulatedState);
        }
    }
}
