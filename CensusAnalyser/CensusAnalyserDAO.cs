using CensusAnalyser.pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
