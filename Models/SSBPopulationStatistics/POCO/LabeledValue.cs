using System.Collections.Generic;

namespace Backend.Models.SSBPopulationStatistics.POCO
{
    public class LabeledValue
    {
        public string municipality;

        /// Format: [ [ year, population ] ]
        public List<PopulationForYear> populationForYear;
    }
}