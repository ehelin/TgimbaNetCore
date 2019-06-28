using Shared.interfaces;
using Shared.dto;
using System.Collections.Generic;

namespace TgimbaNetCoreWebShared.Models
{
    public class SharedWelcomeModel : BaseModel
    {
        //public string[] DashboardData { get; set; }
        public List<SystemStatistic> SystemStatistics = null; 

        public SharedWelcomeModel(ITgimbaService service) : base(service)
        {
            this.SystemStatistics = this.service.GetSystemStatistics();
        }
    }
}
