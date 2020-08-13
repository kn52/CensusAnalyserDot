using CensusAnalyser.poco;

namespace CensusAnalyser
{
    public class CensusAnalyserDTO
    {
        public string state;
        public double population;
        public double totalArea;
        public double totalDensity;
        public string stateCode;

        public CensusAnalyserDTO(IndiaStateCensusCsv indiaStateCensusCsv)
        {
            state = indiaStateCensusCsv.state;
            population = indiaStateCensusCsv.population;
            totalArea = indiaStateCensusCsv.areaInSqKm;
            totalDensity = indiaStateCensusCsv.densityPerSqKm;
        }

        public CensusAnalyserDTO(USCensusCsv census)
        {
            state = census.state;
            stateCode = census.stateCode;
            population = census.population;
            totalArea = census.totalArea;
            totalDensity = census.populationDensity;
        }
    }
}
