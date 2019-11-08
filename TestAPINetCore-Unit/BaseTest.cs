using System;
using APINetCore;
using BLLNetCore.Security;
using Moq;
using Shared;
using Shared.dto;
using Shared.interfaces;
using Shared.misc;

namespace TestAPINetCore_Unit
{
    public class BaseTest
    {
        protected ITgimbaService service { get; set; }
        protected Mock<IBucketListData> mockBucketListData { get; set; }
        protected Mock<IPassword> mockPassword { get; set; }
        protected Mock<IGenerator> mockGenerator { get; set; }
        protected Mock<IString> mockString { get; set; }
        protected Mock<IConversion> mockConversion { get; set; }

        public BaseTest()
        {
            this.mockBucketListData = new Mock<IBucketListData>();
            this.mockPassword = new Mock<IPassword>();
            this.mockGenerator = new Mock<IGenerator>();
            this.mockString = new Mock<IString>();
            this.mockConversion = new Mock<IConversion>();
            this.service = new TgimbaService(this.mockBucketListData.Object, 
                                    mockPassword.Object, mockGenerator.Object,
                                        mockString.Object, mockConversion.Object);
        }

        public User GetUser
        (
            int userId = 1,
            string userName = "userName",
            string password = "password",
            string salt = "salt",
            string email = "email",
            string token = "token"
        ) {
            var user = new User
            {
                UserId = userId,
                UserName = userName,
                Salt = salt,
                Password = password,
                Email = email,
                Token = token,
            };

            return user;
        }

        protected BucketListItem GetBucketListItem
        (
            string userName, 
            string listItemName = "Bucket list item", 
            int dbIdStr = 1
        ) {
            var model = new BucketListItem
            {
                Name = listItemName,
                Created = DateTime.Parse("12/15/2010"),
                Category = Enums.BucketListItemTypes.Hot.ToString(),
                Achieved = true,
                Latitude = (decimal)123.333,
                Longitude = (decimal)555.1345,
                Id = dbIdStr//,
                //UserName = userName
            };

            return model;
        }

        protected string GetBucketListItemSingleString
        (
            string userName = "userName",
            string listItemName = "Bucket list item",
            string dbIdStr = "1",
            bool extended = true
        ) {
            string[] bucketListItem = GetBucketListItem(userName, listItemName, dbIdStr, extended);
            string singleLineBucketListItem = "";

            foreach (string bucketListItemEntry in bucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }

        protected string[] GetBucketListItem
        (
            string userName = "userName",
            string listItemName = "Bucket list item",
            string dbIdStr = "1",
            bool extended = false
        ) {
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

        protected string GetRealJwtToken(int tokenLife = Constants.TOKEN_LIFE) 
        {
            //NOTE: Generating real jwt token for validation tests :)
            var generatorHelper = new GeneratorHelper();
            var jwtPrivateKey = generatorHelper.GetJwtPrivateKey();
            var jwtIssuer = generatorHelper.GetJwtIssuer();
            var jwtToken = generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer, tokenLife);

            return jwtToken;
        }
    }
}
