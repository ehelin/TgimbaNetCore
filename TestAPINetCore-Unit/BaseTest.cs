using System;
using APINetCore;
using BLLNetCore.Security;
using System.Collections.Generic;
using Moq;
using Shared;
using Shared.dto;
using Shared.interfaces;
using Shared.misc;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Search;
using TestAPINetCore_Unit.dto;

namespace TestAPINetCore_Unit
{
    public class BaseTest
    {
        protected ITgimbaService service { get; set; }
        protected Mock<IBucketListData> mockBucketListData { get; set; }
        protected Mock<IPassword> mockPassword { get; set; }
        protected Mock<IGenerator> mockGenerator { get; set; }
        protected Mock<IString> mockString { get; set; }
        protected Mock<IAvailableSortingAlgorithms> mockSortAlgorithm { get; set; }
        protected Mock<IAvailableSearchingAlgorithms> mockSearchAlgorithm { get; set; }
        protected Mock<ISort> mockSort { get; set; }
        protected Mock<ISearch> mockSearch { get; set; }

        public BaseTest()
        {
            this.mockBucketListData = new Mock<IBucketListData>();
            this.mockPassword = new Mock<IPassword>();
            this.mockGenerator = new Mock<IGenerator>();
            this.mockString = new Mock<IString>();
            this.mockSearchAlgorithm = new Mock<IAvailableSearchingAlgorithms>();
            this.mockSortAlgorithm = new Mock<IAvailableSortingAlgorithms>();
            this.mockSort = new Mock<ISort>();
            this.mockSearch = new Mock<ISearch>();
            this.service = new TgimbaService(this.mockBucketListData.Object, 
                                    mockPassword.Object, mockGenerator.Object,
                                        mockString.Object, mockSortAlgorithm.Object,
                                        mockSearchAlgorithm.Object);
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

        protected BucketListItem GetBucketListItemObject
        (
            string userName = "userName", 
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

        protected string GetRealJwtToken(int tokenLife = Constants.TOKEN_LIFE) 
        {
            //NOTE: Generating real jwt token for validation tests :)
            var generatorHelper = new GeneratorHelper();
            var jwtPrivateKey = generatorHelper.GetJwtPrivateKey();
            var jwtIssuer = generatorHelper.GetJwtIssuer();
            var jwtToken = generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer, tokenLife);

            return jwtToken;
        }

        protected TestToken SetUpTokenForTesting(bool validToken)
        {
            var testToken = new TestToken()
            {
                EncodedUserName = "base64EncodedUserName",
                EncodedToken = "base64EncodedToken",
                DecodedUserName = "decodedUser",
                DecodedToken = "decodedToken"
            };
            var userToReturn = GetUser(1, testToken.DecodedUserName);
            this.mockString.Setup(x => x.DecodeBase64String(
                                            It.Is<string>(s => s == testToken.EncodedUserName)))
                                                .Returns("decodedUser");
            this.mockString.Setup(x => x.DecodeBase64String(
                                            It.Is<string>(s => s == testToken.EncodedToken)))
                                                .Returns("decodedToken");
            this.mockBucketListData.Setup(x => x.GetUser(
                                            It.Is<string>(s => s == testToken.DecodedUserName)))
                                                .Returns(userToReturn);
            this.mockPassword.Setup(x => x.IsValidToken(
                                            It.Is<User>(s => s.UserName == userToReturn.UserName),
                                            It.Is<string>(s => s == testToken.DecodedToken)))
                                                .Returns(validToken);

            return testToken;
        }

        protected void TestTokenVerifies(TestToken testToken)
        {
            this.mockString.Verify(x => x.DecodeBase64String(It.Is<string>(s => s == testToken.EncodedUserName)), Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String(It.Is<string>(s => s == testToken.EncodedToken)), Times.Once);
            this.mockBucketListData.Verify(x => x.GetUser(It.Is<string>(s => s == testToken.DecodedUserName)), Times.Once);
            this.mockPassword.Verify(x => x.IsValidToken(
                                                It.Is<User>(s => s.UserName == testToken.DecodedUserName),
                                                    It.Is<string>(s => s == testToken.DecodedToken))
                                                        , Times.Once);
        }
    }
}
