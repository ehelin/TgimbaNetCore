using System.Collections.Generic;

namespace Shared.dto
{
    public class SystemStatistics
    {
        public List<SystemStatistic> SystemStats { get; set; }
        public List<SystemBuildStatistic> SystemBuildStats { get; set; }
    }
}
