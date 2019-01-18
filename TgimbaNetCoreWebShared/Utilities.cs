using System;					 
using Shared.misc;
using TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWebShared
{
	public class Utilities
	{										   
		public static SharedBucketListModel ConvertStringArrayToModel(string[] bucketListItem) 
		{
			SharedBucketListModel model = null;

			if (bucketListItem != null && bucketListItem.Length == 8) // 8 contains fields for 
			{
				model = new SharedBucketListModel{
					Name = bucketListItem[0],
					DateCreated = bucketListItem[1],
					BucketListItemType = Utilities.ConvertCategoryToEnum(bucketListItem[2]),
					Completed = bucketListItem[3] == "1" ? true : false,
					Latitude = bucketListItem[4],			   
					Longitude = bucketListItem[5],
					DatabaseId = bucketListItem[6],
					UserName = bucketListItem[7] 
				};
			}

			return model;
		}

		public static string ConvertModelToString(SharedBucketListModel model) 
		{	   			
			string bucketListItem = null;

			if (model != null)
			{
				bucketListItem = "," + model.Name + ",";	  // leading comma is for tgimba service
				bucketListItem += model.DateCreated + ",";
				bucketListItem += model.BucketListItemType.ToString() + ",";
				bucketListItem += model.Completed == true ? "1,":"0,";
				bucketListItem += model.Latitude + ",";
				bucketListItem += model.Longitude + ",";
				bucketListItem += model.DatabaseId + ",";
				bucketListItem += model.UserName;	
			}

			return bucketListItem;					
		}

		public static Enums.BucketListItemTypes ConvertCategoryToEnum(string category) 
		{
			if(category == "Hot") 
			{
				return Enums.BucketListItemTypes.Hot;
			}
			else if(category == "Warm") 
			{
				return Enums.BucketListItemTypes.Warm;
			} 
			else if(category == "Cold") 
			{
				return Enums.BucketListItemTypes.Cold;
			}
			else 
			{
				throw new Exception("Unknown category: " + category);
			}
		}
	}
}

