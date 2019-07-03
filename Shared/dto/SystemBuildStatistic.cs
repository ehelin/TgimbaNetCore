using System;

namespace Shared.dto
{
    public class SystemBuildStatistic
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string BuildNumber { get; set; }
        public string Status { get; set; }
        public string BuildSource { get; set;}
    }
}
