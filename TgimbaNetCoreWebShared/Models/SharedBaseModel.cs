using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Models
{
    public class BaseModel
    {
        protected ITgimbaService_Old service = null;

        public BaseModel(ITgimbaService_Old service)
        {
            this.service = service;
        }
    }
}
