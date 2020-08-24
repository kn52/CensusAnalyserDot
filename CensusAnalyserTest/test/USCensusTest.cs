namespace CensusAnalyserTest.test
{
    using CensusAnalyser;
    using CensusAnalyser.Comparator;
    using CensusAnalyser.Exception;
    using CensusAnalyser.Poco;
    using Newtonsoft.Json;
    using NUnit.Framework;

    class USCensusTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
        private readonly string US_CENSUS_FILE_PATH = testPath + "csvfiles\\USCensusData.csv";
        private readonly string US_CENSUS_FILE_WRONG_PATH = testPath + "USCensusData.csv";
        private readonly string US_CENSUS_WRONG_TYPE_FILE_PATH = testPath + "csvfiles\\USCensusData.type";
        private readonly string US_CENSUS_WRONG_HEADER_FILE_PATH = testPath + "csvfiles\\USCensusWrongHeader.csv";

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
        public void GivenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(US_CENSUS_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.TypeException);
        }

        [Test]
        public void GivenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(US_CENSUS_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.TypeException);
        }

        [Test]
        public void GivenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT, ex.TypeException);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnState_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Alabama", uSCensusCsv[0].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnState_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Wyoming", uSCensusCsv[uSCensusCsv.Length - 1].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.POPULATION, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("California", uSCensusCsv[0].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnPopulation_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.POPULATION, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Wyoming", uSCensusCsv[uSCensusCsv.Length - 1].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnArea_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.AREA, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("Alaska", uSCensusCsv[0].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnArea_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("desc", CensusAnalyserComparator.SortByField.AREA, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("District of Columbia", uSCensusCsv[uSCensusCsv.Length - 1].State);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnStateCode_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE_CODE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("AK", uSCensusCsv[0].StateCode);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnStateCode_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc", CensusAnalyserComparator.SortByField.STATE_CODE, US_CENSUS_FILE_PATH);
            USCensusCsv[] uSCensusCsv = JsonConvert.DeserializeObject<USCensusCsv[]>(json);
            Assert.AreEqual("WY", uSCensusCsv[uSCensusCsv.Length - 1].StateCode);
        }
    }
}
