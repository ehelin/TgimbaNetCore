using System;

namespace Shared.dto
{
    public class SystemBuildStatistic
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string BuildNumber { get; set; }
        public string Status { get; set; }
        public string BuildSource { get; set;}
    }
}
