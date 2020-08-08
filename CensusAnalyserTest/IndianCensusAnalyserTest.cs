using NUnit.Framework;
using CensusAnalyser;
using CensusAnalyser.exception;

namespace Tests
{
    public class Tests
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
            int length = censusDataAnalyser.loadIndiaCensusData(INDIA_CENSUS_FILE_PATH);
            Assert.AreEqual(29, length);
        }

        [Test]
        public void givenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.loadIndiaCensusData(INDIA_CENSUS_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void givenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.loadIndiaCensusData(INDIA_CENSUS_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.exceptionType);
        }


        [Test]
        public void givenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.loadIndiaCensusData(INDIA_CENSUS_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.exceptionType);
        }

        [Test]
        public void givenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.loadIndiaCensusData(""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.exceptionType);
        }
    }
}