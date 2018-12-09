using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Models
{
    public class SharedWelcomeModel : BaseModel
    {
        public string[] DashboardData { get; set; }

        public SharedWelcomeModel(ITgimbaService service) : base(service)
        {
            this.DashboardData = this.service.GetDashboard();
        }
    }
}
