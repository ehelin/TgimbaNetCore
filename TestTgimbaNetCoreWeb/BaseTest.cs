using Shared.interfaces;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Models;
using TestsAPIIntegration;
using Moq;
using System;
using System.Collections.Generic;

namespace TestTgimbaNetCoreWeb
{
    public class BaseTest
    {
        protected Mock<ITgimbaService> mockITgimbaService { get; set; }
		protected Mock<IWebClient> mockWebClient { get; set; }

        public BaseTest()
        {
            mockITgimbaService = new Mock<ITgimbaService>();  
            mockWebClient = new Mock<IWebClient>();

            SetupGetDashboard();
			SetupWebClient();
        }					

        private void SetupGetDashboard()
        {
            string[] data = new string[]
            {
                "result 1", "result 2", "result 3", "result 4", "result 5",
                "result 6", "result 7", "result 8", "result 9", "result 10"
            };
            mockITgimbaService.Setup(x => x.GetDashboard()).Returns(data);
        }

		private void SetupWebClient() {
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedGoodUser", "base64EncodedGoodPass")).Returns("token");
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedBadUser", "base64EncodedBadPass")).Returns("");
			mockITgimbaService.Setup(x => x.ProcessUserRegistration(
																	"base64EncodedGoodUser", 
																	"base64EncodedGoodEmail", 
																	"base64EncodedGoodPass"
																	)).Returns(true);
			mockITgimbaService.Setup(x => x.ProcessUserRegistration(
																	"base64EncodedBadUser", 
																	"base64EncodedBadEmail", 
																	"base64EncodedBadPass"
																	)).Returns(false);
																												  
			var bucketListItems = TestUtilities.GetBucketListItem("base64EncodedGoodUser","newBucketListItem", "dbId", true);
			mockITgimbaService.Setup(x => x.GetBucketListItemsV2(						 
																"base64EncodedGoodUser", 
																"base64EncodedGoodSortString", 
																"base64EncodedGoodToken"
																)).Returns(bucketListItems);  		
																												  
			string[] noResult = new string[] {"No Items"};
			mockITgimbaService.Setup(x => x.GetBucketListItemsV2(						 
																"base64EncodedBadUser", 
																"base64EncodedBadSortString", 
																"base64EncodenBadToken"
																)).Returns(noResult);
						  			   													  
			string[] upsertResult = new string[] {"TokenValid"};
			var encodedBucketListItemsSingleLine = TestUtilities.GetBucketListItemSingleString(
																			"base64EncodedGoodUser",
																			"newBucketListItem", 
																			"dbId", 
																			true);				
			mockITgimbaService.Setup(x => x.UpsertBucketListItemV2(
																encodedBucketListItemsSingleLine,
																"base64EncodedGoodUser", 		  
																"base64EncodedGoodToken"
																)).Returns(upsertResult);

			upsertResult = new string[] {"ERR_000002-Token Expired"};
			encodedBucketListItemsSingleLine = TestUtilities.GetBucketListItemSingleString(
																			"base64EncodedBadUser",
																			"newBucketListItem", 
																			"dbId", 
																			true);				
			mockITgimbaService.Setup(x => x.UpsertBucketListItemV2(
																encodedBucketListItemsSingleLine,
																"base64EncodedGoodUser", 		  
																"base64EncodedGoodToken"
																)).Returns(upsertResult);					
		}
		
		protected SharedBucketListModel GetBucketListModel(string dbId = null)
		{
			var model = new SharedBucketListModel
			{
				Name = "Test Bucket List Item",
				DateCreated = DateTime.UtcNow.ToString(),
				Type = Shared.misc.Enums.BucketListItemTypes.Hot,
				Completed = false,
				Latitude = "Lat",
				Longitude = "Lon",
				DatabaseId = dbId,
				UserName = "userName"
			};

			return model;
		}
	}
}
