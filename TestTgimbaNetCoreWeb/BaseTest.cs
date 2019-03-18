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
			SetUpTgimbaServiceProcessUser();
			SetUpTgimbaServiceProcessUserRegistration();
			SetUpTgimbaServiceAddBucketListItem();
			SetUpTgimbaServiceDeleteBucketListItem();
			SetUpTgimbaServiceAddEditBucketListItem();					
		}
		private void SetupWebClient() 
		{																										  
			var bucketListItem = TestUtilities.GetBucketListItemModel("base64EncodedGoodUser","newBucketListItem", "dbId", true);
			var bucketListItems = new List<SharedBucketListModel>();
			bucketListItems.Add(bucketListItem);
			mockWebClient.Setup(x => x.GetBucketListItems(						 
														"YmFzZTY0RW5jb2RlZEdvb2RVc2Vy",//"base64EncodedGoodUser", 
														"base64EncodedGoodSortString", 
														"base64EncodedGoodToken",
														"base64EncodedGoodSrchTerm"
														)).Returns(bucketListItems);  		

			mockWebClient.Setup(x => x.AddBucketListItem(
														It.IsAny<SharedBucketListModel>(),
														"base64EncodedGoodUser", 		
														"base64EncodedGoodToken"
														)).Returns(true);
			  
			mockWebClient.Setup(x => x.EditBucketListItem(
														It.Is<SharedBucketListModel>(a => !string.IsNullOrEmpty(a.DatabaseId)),
														"base64EncodedGoodUser", 		
														"base64EncodedGoodToken"
														)).Returns(true);

			mockWebClient.Setup(x => x.DeleteBucketListItem(
														It.Is<string>(a => !string.IsNullOrEmpty(a)),
														"base64EncodedGoodUser", 		
														"base64EncodedGoodToken"
														)).Returns(true);		
		}

		private void SetUpTgimbaServiceProcessUser() {			
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedGoodUser", "base64EncodedGoodPass")).Returns("token");
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedBadUser", "base64EncodedBadPass")).Returns("");
		}
		private void SetUpTgimbaServiceProcessUserRegistration() {														
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
		} 
		private void SetUpTgimbaServiceGetBucketListItems() {			
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedGoodUser", "base64EncodedGoodPass")).Returns("token");
			mockITgimbaService.Setup(x => x.ProcessUser("base64EncodedBadUser", "base64EncodedBadPass")).Returns("");
		} 												  
		private void SetUpTgimbaServiceAddBucketListItem() {	
			var bucketListItemSingleLine = TestUtilities.GetBucketListItemSingleString("base64EncodedGoodUser","newBucketListItem", "dbId", true);
			string[] bucketLIstitems = new string[] { bucketListItemSingleLine };											
			mockITgimbaService.Setup(x => x.GetBucketListItemsV2(						 
																"YmFzZTY0RW5jb2RlZEdvb2RVc2Vy", 
																"base64EncodedGoodSortString", 
																"base64EncodedGoodToken",
																"base64EncodedGoodSrchTerm"
																)).Returns(bucketLIstitems);  	
		}
		private void SetUpTgimbaServiceDeleteBucketListItem() {						 				  
			string[] upsertResult = new string[] {"TokenValid"};
			mockITgimbaService.Setup(x => x.DeleteBucketListItem(123, 
																"base64EncodedGoodUser", 		  
																"base64EncodedGoodToken"   
																)).Returns(upsertResult); 
		}
		private void SetUpTgimbaServiceAddEditBucketListItem() {									  
			string[] upsertResult = new string[] {"TokenValid"};
			var encodedBucketListItemsSingleLine = TestUtilities.GetBucketListItemSingleString(
																			"base64EncodedGoodUser",
																			"newBucketListItem", 
																			null, 
																			true);	
			var editedEncodedBucketListItemsSingleLine = TestUtilities.GetBucketListItemSingleString(
																			"base64EncodedGoodUser",
																			"editedBucketListItem", 
																			"123", 
																			true);	
			encodedBucketListItemsSingleLine = Shared.misc.Utilities.EncodeClientBase64String(encodedBucketListItemsSingleLine);	
			editedEncodedBucketListItemsSingleLine = Shared.misc.Utilities.EncodeClientBase64String(editedEncodedBucketListItemsSingleLine);				
				
			mockITgimbaService.Setup(x => x.UpsertBucketListItemV2(
																It.IsAny<string>(),
																"base64EncodedGoodUser", 		  
																"base64EncodedGoodToken"
																)).Returns(
																(
																	string encodedBucketListItems, 
																	string encodedUser, 
																	string encodedToken
																) =>
																{
																	if (encodedBucketListItems == encodedBucketListItemsSingleLine
																		|| encodedBucketListItems == editedEncodedBucketListItemsSingleLine) 
																	{
																		return upsertResult;
																	}
																	return null;
																});						
		}
	}
}
