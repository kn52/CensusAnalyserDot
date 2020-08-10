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
            this.state = indiaStateCensusCsv.state;
            this.population = indiaStateCensusCsv.population;
            this.totalArea = indiaStateCensusCsv.areaInSqKm;
            this.totalDensity = indiaStateCensusCsv.densityPerSqKm;
        }

        public CensusAnalyserDAO(IndiaStateCodeCsv indiaStateCodeCsv)
        {
            this.state = indiaStateCodeCsv.state;
            this.stateCode = indiaStateCodeCsv.stateCode;
        }
    }
}
