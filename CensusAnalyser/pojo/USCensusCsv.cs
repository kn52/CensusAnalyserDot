using CsvHelper.Configuration.Attributes;

namespace CensusAnalyser.pojo
{
    public class USCensusCsv
    {
        [Name("State Id")]
        public string stateCode { get; set; }

        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public double population { get; set; }

        [Name("Housing units")]
        public double housingUnits { get; set; }

        [Name("Total area")]
        public double totalArea { get; set; }

        [Name("Water area")]
        public double waterArea { get; set; }

        [Name("Land area")]
        public double landArea { get; set; }

        [Name("Population Density")]
        public double populationDensity { get; set; }

        [Name("Housing Density")]
        public double housingDensity { get; set; }
    }
}