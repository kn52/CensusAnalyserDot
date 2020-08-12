using System.Collections.Generic;

namespace CensusAnalyser.comparator
{
    public class CensusAnalyserComparator : Comparer<CensusAnalyserDTO>
    {
        public enum SortByField
        {
            STATE,
            STATE_CODE,
            POPULATION,
            DENSITY,
            AREA,
        }

        public SortByField compareByField;

        public CensusAnalyserComparator(SortByField sortByField)
        {
            compareByField = sortByField;
        }
        public override int Compare(CensusAnalyserDTO x, CensusAnalyserDTO y)
        {
            switch (compareByField)
            {

                case SortByField.STATE:
                    return x.state.CompareTo(y.state);
                case SortByField.STATE_CODE:
                    return x.stateCode.CompareTo(y.stateCode);
                case SortByField.POPULATION:
                    return x.population.CompareTo(y.population);
                case SortByField.DENSITY:
                    return x.totalDensity.CompareTo(y.totalDensity);
                case SortByField.AREA:
                    return x.totalArea.CompareTo(y.totalArea);
                default:
                    break;
            }
            return x.state.CompareTo(y.state);
        }
    }
}
