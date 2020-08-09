using NUnit.Framework;
using CensusAnalyser;
using CensusAnalyser.exception;

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
        public void givenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int length = censusDataAnalyser.readCsvFile(INDIA_STATECODE_FILE_PATH);
            Assert.AreEqual(37, length);
        }

        [Test]
        public void givenCSVFilePath_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_STATECODE_FILE_WRONG_PATH));
            Assert.AreEqual("File Not Found", ex.Message);
        }

        [Test]
        public void givenCSVFileType_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_STATECODE_WRONG_TYPE_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.exceptionType);
        }


        [Test]
        public void givenCSVFileHeader_WhenIncorrect_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(INDIA_STATECODE_WRONG_HEADER_FILE_PATH));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.WRONG_HEADER, ex.exceptionType);
        }

        [Test]
        public void givenCSVFilePath_IsEmpty_willthrowException()
        {
            var ex = Assert.Throws<CensusDataAnalyserException>(
                () => censusDataAnalyser.readCsvFile(""));
            Assert.AreEqual(CensusDataAnalyserException.ExceptionType.INVALID_ARGUMENT, ex.exceptionType);
        }
    }
}
