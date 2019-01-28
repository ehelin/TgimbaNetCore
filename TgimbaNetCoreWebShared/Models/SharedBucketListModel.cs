using Shared.misc;
using System.Runtime.Serialization;

namespace TgimbaNetCoreWebShared.Models
{
	[DataContract]
	public class SharedBucketListModel
	{
		[DataMember]
		public string Name { get; set;}	  
		[DataMember]
		public string DateCreated { get; set;}	
		[DataMember]  
		public Enums.BucketListItemTypes BucketListItemType { get; set;}
		[DataMember]
		public bool Completed { get; set;} 
		[DataMember]
		public string Latitude { get; set;}	  
		[DataMember]
		public string Longitude { get; set;}  
		[DataMember]
		public string DatabaseId { get; set;}
		[DataMember]		 
		public string UserName { get; set;}			   
	}
}
