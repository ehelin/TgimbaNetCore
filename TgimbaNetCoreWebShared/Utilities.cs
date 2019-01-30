using System;		
using System.Collections.Generic;			 
using Shared.misc;
using TgimbaNetCoreWebShared.Models;

namespace TgimbaNetCoreWebShared
{
	public class Utilities
	{										   
		public static List<SharedBucketListModel> ConvertStringArrayToModelList(string[] bucketListItems) 
		{
			List<SharedBucketListModel> modelList = null;
			SharedBucketListModel model = null;

			if (bucketListItems != null && bucketListItems.Length > 0) 
			{
				modelList = new List<SharedBucketListModel>();

				foreach(string bucketListItemStr in bucketListItems) 
				{
					string[] bucketListItem = bucketListItemStr.Split(',');

					// TODO - handle expired token error = ERR_000002-Token Expired
					if (bucketListItem[0] == "ERR_000002-Token Expired") {
						model = new SharedBucketListModel{ 
							DatabaseId = "ERR_000002-Token Expired"
						};	   
					} 
					// TODO - handle no items
					else if (bucketListItem[0] == "No Items") {
						break;
						//model = new SharedBucketListModel{ 
						//	DatabaseId = "No Items"
						//};	 
					}
					else {																							
						model = new SharedBucketListModel{
							Name = bucketListItem[1],
							DateCreated = bucketListItem[2],
							BucketListItemType = Utilities.ConvertCategoryToEnum(bucketListItem[3]),
							Completed = bucketListItem[4] == "1" ? true : false,
							Latitude = bucketListItem[5],			   
							Longitude = bucketListItem[6],
							DatabaseId = bucketListItem[7] != "" ? bucketListItem[7] : null//,
							//UserName = bucketListItem[7] 
						};
					}
			
					modelList.Add(model);
				}
			}

			return modelList;
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
			else if(category == "Cool") 
			{
				return Enums.BucketListItemTypes.Cool;
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

