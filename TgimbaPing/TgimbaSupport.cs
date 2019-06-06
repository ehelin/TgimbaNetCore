using Shared.interfaces;

namespace TgimbaSupport
{
    public class TgimbaPing : ITgimbaPing
    {
        private string url;
        private ITgimbaHttpClient tgimbaHttpClient;
        private ITgimbaDatabase tgimbaDatabase;

        public TgimbaPing
        (
            string url, 
            ITgimbaHttpClient tgimbaHttpClient, 
            ITgimbaDatabase tgimbaDatabase
        ) 
        {
            this.url = url;
            this.tgimbaHttpClient = tgimbaHttpClient;
            this.tgimbaDatabase = tgimbaDatabase;
        }

        public void PingWebSite()
        {
            bool websiteIsUp = this.tgimbaHttpClient.Get(this.url);
            tgimbaDatabase.SaveWebsiteStatus(websiteIsUp);
        }
    }
}
