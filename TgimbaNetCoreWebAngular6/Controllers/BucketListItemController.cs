using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		
using TgimbaNetCoreWebShared; 
using TgimbaNetCoreWebShared.Controllers;
using TgimbaNetCoreWebShared.Models;	
using System.Collections.Generic;   

namespace TgimbaNetCoreWeb.Controllers
{				 
	//[RequireHttpsAttribute]
    public class BucketListItemController : Controller
    {
		private SharedBucketListController sharedBucketListController = null;

        public BucketListItemController(ITgimbaService service, IWebClient webClient)
        {
			sharedBucketListController = new SharedBucketListController(service, webClient);
		}	  
								
		[HttpPost]
        public bool EditBucketListItem([FromBody] SharedBucketListModel model)
        {
			return sharedBucketListController.EditBucketListItem(model, model.encodedUser, model.encodedToken);
        }		
							      
        [HttpDelete]
        public bool DeleteBucketListItem([FromBody] SharedDeleteModel model)
        {									   																	  
			return sharedBucketListController.DeleteBucketListItem(model.DbId, model.Username, model.Token);
        }					  
			
		[HttpPost]
        public bool AddBucketListItemJQuery([FromBody] SharedBucketListModel model)
        {
			return sharedBucketListController.AddBucketListItem(model, model.encodedUser, model.encodedToken);
        }

        [HttpPost]
        public bool AddBucketListItem(string Name, string DateCreated, string BucketListItemType, string Completed, 
									string Latitude,string Longitude, string DatabaseId, string UserName, 
									string encodedUser, string encodedToken)
        {
            var model = ConvertArgsToModel(Name, DateCreated, BucketListItemType, Completed, 
												Latitude, Longitude, DatabaseId, UserName);
			
			return sharedBucketListController.AddBucketListItem(model, encodedUser,	encodedToken);
        }
		   
        [HttpGet]
        public List<SharedBucketListModel> GetBucketListItems(string encodedUserName, string encoderedSortString, string encodedToken)
        {
            return sharedBucketListController.GetBucketListItems(encodedUserName, encoderedSortString, encodedToken);
        }	 

		// TODO - temp solution - figure out why Vanilla javascript model has null values
		private SharedBucketListModel ConvertArgsToModel(string Name, string DateCreated, string BucketListItemType, string Completed, 
														string Latitude,string Longitude, string DatabaseId, string UserName) {
			var model = new SharedBucketListModel() {
				Name = Name, 
				DateCreated = DateCreated,
				BucketListItemType = Utilities.ConvertCategoryToEnum(BucketListItemType),
				Completed = System.Convert.ToBoolean(Completed),
				Latitude = Latitude,  
				Longitude = Longitude,
				DatabaseId = DatabaseId,
				UserName =	 UserName
			};

			return model;
		}
    }
}
