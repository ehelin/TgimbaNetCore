namespace DALNetCore.Models
{
    public partial class BrowserCapability
    {
        public long BrowserCapabilityId { get; set; }
        public long? BrowserLogId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Tett { get; set; }
    }
}
