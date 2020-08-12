using CsvHelper.Configuration.Attributes;

namespace CensusAnalyser.poco
{
    public class IndiaStateCensusCsv
    {
        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public double population { get; set; }

        [Name("AreaInSqKm")]
        public double areaInSqKm { get; set; }
        
        [Name("DensityPerSqKm")]
        public double densityPerSqKm { get; set; }
    }
}