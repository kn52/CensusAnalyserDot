namespace CensusAnalyserTest.test
{
    using CensusAnalyser;
    using CensusAnalyser.Comparator;
    using CensusAnalyser.Exception;
    using CensusAnalyser.Poco;
    using Newtonsoft.Json;
    using NUnit.Framework;

    class IndiaStateCodeTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
        private readonly string INDIA_CENSUS_FILE_PATH = testPath + "csvfiles\\IndiaStateCensusData.csv";
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
            int count = censusDataAnalyser.GetFileRecordCount(INDIA_CENSUS_FILE_PATH,INDIA_STATECODE_FILE_PATH);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void GivenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_FILE_PATH, INDIA_STATECODE_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void GivenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_FILE_PATH, INDIA_STATECODE_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.TypeException);
        }


        [Test]
        public void GivenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile(INDIA_CENSUS_FILE_PATH, INDIA_STATECODE_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.TypeException);
        }

        [Test]
        public void GivenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.ReadCsvFile("", ""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT, ex.TypeException);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnName_ShouldReturnJson_AndCheckingFirstIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc",CensusAnalyserComparator.SortByField.STATE,INDIA_CENSUS_FILE_PATH, INDIA_STATECODE_FILE_PATH);
            IndiaStateCodeCsv[] indiaStateCodeCsv = JsonConvert.DeserializeObject<IndiaStateCodeCsv[]>(json);
            Assert.AreEqual("AP", indiaStateCodeCsv[0].StateCode);
        }

        [Test]
        public void GivenCsvFilePath_WhenSortedOnName_ShouldReturnJson_AndCheckingLastIndex()
        {
            string json = censusDataAnalyser.GetIndiaStateSortedByField("asc",CensusAnalyserComparator.SortByField.STATE,INDIA_CENSUS_FILE_PATH, INDIA_STATECODE_FILE_PATH);
            IndiaStateCodeCsv[] indiaStateCodeCsv = JsonConvert.DeserializeObject<IndiaStateCodeCsv[]>(json);
            Assert.AreEqual("WB", indiaStateCodeCsv[indiaStateCodeCsv.Length - 1].StateCode);
        }
    }
}
