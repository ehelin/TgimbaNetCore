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
			SetUpTgimbaService();
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

		private void SetUpTgimbaService() {
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
																												  
			var bucketListItemSingleLine = TestUtilities.GetBucketListItemSingleString("base64EncodedGoodUser","newBucketListItem", "dbId", true);
			string[] bucketLIstitems = new string[] { bucketListItemSingleLine };											
			mockITgimbaService.Setup(x => x.GetBucketListItemsV2(						 
																"base64EncodedGoodUser", 
																"base64EncodedGoodSortString", 
																"base64EncodedGoodToken"
																)).Returns(bucketLIstitems);  		
						  			   													  
			string[] upsertResult = new string[] {"TokenValid"};
			var encodedBucketListItemsSingleLine = TestUtilities.GetBucketListItemSingleString(
																			"base64EncodedGoodUser",
																			"newBucketListItem", 
																			null, 
																			true);				
			mockITgimbaService.Setup(x => x.UpsertBucketListItemV2(
																encodedBucketListItemsSingleLine,
																"base64EncodedGoodUser", 		  
																"base64EncodedGoodToken"
																)).Returns(upsertResult);
		}
		private void SetupWebClient() 
		{																										  
			var bucketListItem = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser","newBucketListItem", "dbId", true);
			var bucketListItems = new List<SharedBucketListModel>();
			bucketListItems.Add(bucketListItem);
			mockWebClient.Setup(x => x.GetBucketListItems(						 
														"base64EncodedGoodUser", 
														"base64EncodedGoodSortString", 
														"base64EncodedGoodToken"
														)).Returns(bucketListItems);  		

			mockWebClient.Setup(x => x.AddBucketListItem(
														It.IsAny<SharedBucketListModel>(),
														"base64EncodedGoodUser", 		
														"base64EncodedGoodToken"
														)).Returns(true);
		}
	}
}
