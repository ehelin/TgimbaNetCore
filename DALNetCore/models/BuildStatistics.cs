using System;

namespace DALNetCore.models
{
    public class BuildStatistics
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string BuildNumber { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
