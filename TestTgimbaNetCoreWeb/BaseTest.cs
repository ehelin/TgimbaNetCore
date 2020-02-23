using System.Collections.Generic;
using Moq;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Models;

namespace TestTgimbaNetCoreWeb
{
    public class BaseTest
    {
        protected Mock<IWebClient> mockWebClient { get; set; }
        protected Mock<ITgimbaHttpClient> mockTgimbaHttpClient { get; set; }

        public BaseTest()
        {
            mockWebClient = new Mock<IWebClient>();
            mockTgimbaHttpClient = new Mock<ITgimbaHttpClient>();

            SetupWebClient();
        }

        private void SetupWebClient()
        {
            var bucketListItem = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", "dbId", true);
            var bucketListItems = new List<SharedBucketListModel>();
            bucketListItems.Add(bucketListItem);
            mockWebClient.Setup(x => x.GetBucketListItems(
                                                        "YmFzZTY0RW5jb2RlZEdvb2RVc2Vy",//"base64EncodedGoodUser", 
                                                        "base64EncodedGoodSortString",
                                                        "base64EncodedGoodToken",
                                                        "base64EncodedGoodSrchTerm",
                                                        "base64EncodedGoodSortType",
                                                        "base64EncodedGoodSearchType"
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

            mockWebClient.Setup(x => x.Login("base64EncodedGoodUser", 
                                                "base64EncodedGoodPass"))
                                                    .Returns("token");

            mockWebClient.Setup(x => x.Registration("base64EncodedGoodUser",
                                                        "base64EncodedGoodEmail",
                                                            "base64EncodedGoodPass"))
                                                                .Returns(true);
}

        #region To Delete

        protected SharedBucketListModel GetBucketListItemModel(string userName, string listItemName = "", string dbIdStr = "", bool extended = false)
        {
            SharedBucketListModel model = new SharedBucketListModel
            {
                Name = listItemName,
                DateCreated = "12/15/2010",
                BucketListItemType = Shared.misc.Enums.BucketListItemTypes.Hot, // TODO - set
                Completed = true,
                Latitude = "123.333",
                Longitude = "555.1345",
                DatabaseId = dbIdStr,
                UserName = userName
            };

            return model;
        }

        protected string GetBucketListItemDbId(string singleLineBucketListItem)
        {
            int pos = singleLineBucketListItem.LastIndexOf(',');
            string dbIdStr = singleLineBucketListItem.Substring(pos + 1, singleLineBucketListItem.Length - (pos + 1));

            return dbIdStr;
        }

        protected string GetBucketListItemSingleString(string userName, string listItemName, string dbIdStr, bool extended = false)
        {
            string[] bucketListItem = GetBucketListItem(userName, listItemName, dbIdStr, extended);
            string singleLineBucketListItem = "";

            foreach (string bucketListItemEntry in bucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }

        protected string[] GetBucketListItem(string userName, string listItemName = "", string dbIdStr = "", bool extended = false)
        {
            string[] bucketListItems;

            if (extended)
            {
                bucketListItems = new string[8];
            }
            else
            {
                bucketListItems = new string[6];
            }

            bucketListItems[0] = listItemName;
            bucketListItems[1] = "12/15/2010";
            bucketListItems[2] = "Hot";
            bucketListItems[3] = "1";

            if (extended)
            {
                bucketListItems[4] = "123.333";
                bucketListItems[5] = "555.1345";
                bucketListItems[6] = dbIdStr;
                bucketListItems[7] = userName;
            }
            else
            {
                bucketListItems[4] = dbIdStr;
                bucketListItems[5] = userName;
            }

            return bucketListItems;
        }

        #endregion
    }
}
