using CsvHelper.Configuration.Attributes;

namespace CensusAnalyser.poco
{
    public class IndiaStateCodeCsv
    {
        [Name("SrNo")]
        public int srNo { get; set; }

        [Name("State Name")]
        public string state { get; set; }

        [Name("TIN")]
        public int pin { get; set; }

        [Name("StateCode")]
        public string stateCode { get; set; }
        
    }
}
