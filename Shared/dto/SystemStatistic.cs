using System;

namespace Shared.dto
{
    public class SystemStatistic
    {
        public bool WebSiteIsUp { get; set; }
        public bool DatabaseIsUp { get; set; }
        public bool AzureFunctionIsUp { get; set; }
        public DateTime Created { get; set;}
    }
}
