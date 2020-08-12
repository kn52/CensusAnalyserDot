using NUnit.Framework;
using CensusAnalyser;
using CensusAnalyser.exception;
using CensusAnalyser.poco;
using Newtonsoft.Json;
using CensusAnalyser.comparator;

namespace CensusAnalyserTest.test
{
    class IndiaStateCensusTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
        private readonly string INDIA_CENSUS_FILE_PATH = testPath + "csvfiles\\IndiaStateCensusData.csv";
        private readonly string INDIA_CENSUS_FILE_WRONG_PATH = testPath + "IndiaStateCensusData.csv";
        private readonly string INDIA_CENSUS_WRONG_TYPE_FILE_PATH = testPath + "csvfiles\\IndiaStateCensusData.type";
        private readonly string INDIA_CENSUS_WRONG_HEADER_FILE_PATH = testPath + "csvfiles\\IndiaStateCensusWrongHeader.csv";

        CensusDataAnalyser censusDataAnalyser;

        [SetUp]
        public void Setup()
        {
            censusDataAnalyser = new CensusDataAnalyser();
        }

        [Test]
        public void GivenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int count = censusDataAnalyser.GetFileRecordCount(INDIA_CENSUS_FILE_PATH);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void GivenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void GivenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.exceptionType);
        }


        [Test]
        public void GivenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_WRONG_HEADER_FILE_PATH));
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
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc",CensusAnalyserComparator.SortByField.STATE,INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Andhra Pradesh", indiaStateCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnName_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc",CensusAnalyserComparator.SortByField.STATE,INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("West Bengal", indiaStateCensusCsv[indiaStateCensusCsv.Length - 1].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.POPULATION, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Uttar Pradesh", indiaStateCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.POPULATION, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Sikkim", indiaStateCensusCsv[indiaStateCensusCsv.Length - 1].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnDensity_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.DENSITY, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Bihar", indiaStateCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnDensity_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.DENSITY, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Arunachal Pradesh", indiaStateCensusCsv[indiaStateCensusCsv.Length - 1].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnArea_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.AREA, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Rajasthan", indiaStateCensusCsv[0].state);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnArea_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc",CensusAnalyserComparator.SortByField.AREA, INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Goa", indiaStateCensusCsv[indiaStateCensusCsv.Length - 1].state);
        }
    }
}
