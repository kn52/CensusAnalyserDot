using CensusAnalyser.pojo;

namespace CensusAnalyser
{
    public class CensusAnalyserDAO
    {
        public string state;
        public double population;
        public double totalArea;
        public double totalDensity;
        public string stateCode;

        public CensusAnalyserDAO(IndiaStateCensusCsv indiaStateCensusCsv)
        {
            state = indiaStateCensusCsv.state;
            population = indiaStateCensusCsv.population;
            totalArea = indiaStateCensusCsv.areaInSqKm;
            totalDensity = indiaStateCensusCsv.densityPerSqKm;
        }

        public CensusAnalyserDAO(USCensusCsv census)
        {
            state = census.state;
            stateCode = census.stateCode;
            population = census.population;
            totalArea = census.totalArea;
            totalDensity = census.populationDensity;
        }
    }
}
