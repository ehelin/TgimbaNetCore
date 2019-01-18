using Shared.misc;

namespace TgimbaNetCoreWebShared.Models
{
	public class SharedBucketListModel
	{
		public string Name { get; set;}	 
		public string DateCreated { get; set;}	  
		public Enums.BucketListItemTypes BucketListItemType { get; set;}
		public bool Completed { get; set;}
		public string Latitude { get; set;}
		public string Longitude { get; set;}
		public string DatabaseId { get; set;}		 
		public string UserName { get; set;}			   
	}
}
