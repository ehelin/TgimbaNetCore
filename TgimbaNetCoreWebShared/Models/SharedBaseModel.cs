using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Models
{
    public class BaseModel
    {
        protected ITgimbaService service = null;

        public BaseModel(ITgimbaService service)
        {
            this.service = service;
        }
    }
}
