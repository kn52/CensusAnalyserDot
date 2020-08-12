using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest.test
{
    class USCensusTest
    {
        static readonly string testPath = "D:\\AAA\\VisualStudio\\CensusAnalyserSln\\CensusAnalyserTest";
        private readonly string US_CENSUS_FILE_PATH = testPath + "\\csvfiles\\USCensusData.csv";

        CensusDataAnalyser censusDataAnalyser;

        [SetUp]
        public void Setup()
        {
            censusDataAnalyser = new CensusDataAnalyser();
        }

        [Test]
        public void GivenCSVFilePath_WhenCorrect_willReturnTotalCount()
        {
            int count = censusDataAnalyser.ReadUSFile(US_CENSUS_FILE_PATH);
            Assert.AreEqual(51, count);
        }
    }
}
