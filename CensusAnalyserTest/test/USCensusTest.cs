using CensusAnalyser;
using CensusAnalyser.exception;
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
    }
}
