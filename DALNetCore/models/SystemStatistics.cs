using System;

namespace DALNetCore.Models
{
    public class SystemStatistics
    {
        public Int64 Id { get; set; }
        public bool WebsiteIsUp { get; set; }
        public bool DatabaseIsUp { get; set; }
        public bool AzureFunctionIsUp { get; set; }
        public DateTime? Created { get; set; }
    }
}
