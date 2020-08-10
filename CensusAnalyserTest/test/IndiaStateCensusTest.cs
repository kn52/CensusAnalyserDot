using NUnit.Framework;
using CensusAnalyser;
using CensusAnalyser.exception;
using CensusAnalyser.pojo;
using Newtonsoft.Json;
namespace CensusAnalyserTest
{
    class IndiaStateCensusTest
    {
        static string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest\\";
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
        public void givenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int count = censusDataAnalyser.getFileRecordCount(INDIA_CENSUS_FILE_PATH);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void givenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_CENSUS_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void givenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_CENSUS_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.exceptionType);
        }


        [Test]
        public void givenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_CENSUS_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.exceptionType);
        }

        [Test]
        public void givenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT, ex.exceptionType);
        }

        [Test]
        public void givenCsvFilePath_WhenSortedOnName_ShouldReturnJson()
        {
            string json = censusDataAnalyser.getIndiaStateCensusSortedByName(INDIA_CENSUS_FILE_PATH);
            IndiaStateCensusCsv[] indiaStateCensusCsv = JsonConvert.DeserializeObject<IndiaStateCensusCsv[]>(json);
            Assert.AreEqual("Andhra Pradesh", indiaStateCensusCsv[0].state);
        }
    }
}
