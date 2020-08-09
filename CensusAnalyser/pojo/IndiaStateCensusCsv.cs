using CsvHelper.Configuration.Attributes;

namespace CensusAnalyser.pojo
{
    public class IndiaStateCensusCsv
    {
        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public string population { get; set; }

        [Name("AreaInSqKm")]
        public double areaInSqKm { get; set; }

        [Name("DensityPerSqKm")]
        public double densityPerSqKm { get; set; }
    }
}