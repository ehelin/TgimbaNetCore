﻿using System;		
using System.Collections.Generic;			 
using Shared.misc;
using TgimbaNetCoreWebShared.Models; 
using System.Text.RegularExpressions;  

namespace TgimbaNetCoreWebShared
{
	public class Utilities
	{								
		public static bool IsMobile(string userAgent) 
		{
            // NOTE: Regex from http://detectmobilebrowsers.com/ 
            Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            if ((b.IsMatch(userAgent) || v.IsMatch(userAgent.Substring(0, 4))))
            {
                return true;
            }

            return false;
        }
		   
        public static string[] GetAvailableSortingAlgorithms()
        {
            var availableSortingAlgorithms = Enum.GetNames(typeof(Enums.SortAlgorithms));

            return availableSortingAlgorithms;
        }

		public static List<SharedBucketListModel> ConvertStringArrayToModelList(string[] bucketListItems, string encodedUserName = "") 
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
							DatabaseId = bucketListItem[7] != "" ? bucketListItem[7] : null,//,
							UserName = !string.IsNullOrEmpty(encodedUserName) 
											? Shared.misc.Utilities.DecodeClientBase64String(encodedUserName) 
												: ""
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

