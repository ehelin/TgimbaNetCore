using System;

namespace DALNetCore.models
{
    public class SystemStatistics
    {
        public int Id { get; set; }
        public bool WebsiteIsUp { get; set; }
        public bool DatabaseIsUp { get; set; }
        public bool AzureFunctionIsUp { get; set; }
        public DateTime? Created { get; set; }
    }
}
