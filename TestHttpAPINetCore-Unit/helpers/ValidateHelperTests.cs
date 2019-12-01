using HttpAPINetCore.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System;
using Shared.dto.api;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class ValidateHelperTests 
    {
        private IValidationHelper sut = null;

        public ValidateHelperTests() {
            sut = new ValidationHelper();
        }

        #region IsValidRequest - DeleteBucketListItemRequest

        [DataTestMethod]
        [DataRow(1, false, false)]
        [DataRow(0, false, true)]
        [DataRow(0, true, true)]
        public void IsValidRequest_DeleteBucketListItemRequest_Tests
        (
            int id, 
            bool nullRequest,
            bool validationErrorExpected
        ) {
            DeleteBucketListItemRequest request = null;

            if (!nullRequest)
            {
                request = new DeleteBucketListItemRequest() 
                { 
                    BucketListItemId = id,
                    Token = SetTokenRequest()
                };
            }
                
            try 
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);  
            } 
            catch (Exception ex) 
            {
                Assert.IsTrue(validationErrorExpected);  
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion


        #region IsValidRequest - GetBucketListItemRequest

        [DataTestMethod]
        [DataRow(false, false)]
        [DataRow(true, true)]
        public void IsValidRequest_GetBucketListItemRequest_Tests
        (
            bool nullRequest,
            bool validationErrorExpected
        )
        {
            GetBucketListItemRequest request = null;

            if (!nullRequest)
            {
                request = new GetBucketListItemRequest()
                {
                    Token = SetTokenRequest()
                };
            }

            try
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(validationErrorExpected);
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion

        #region IsValidRequest - LoginRequest

        [DataTestMethod]
        [DataRow("userName", "password", false, false)]     // happy path
        [DataRow(null, "password", false, true)]            // null userName
        [DataRow("", "password", false, true)]              // empty userName
        [DataRow("userName", null, false, true)]            // null password
        [DataRow("userName", "", false, true)]              // empty password
        [DataRow(null, null, true, true)]                   // null request
        public void IsValidRequest_LoginRequest_Tests
        (
            string userName,
            string password,
            bool nullRequest,
            bool validationErrorExpected
        )
        {
            LoginRequest request = null;

            if (!nullRequest)
            {
                request = SetLoginRequest(userName, password);
            }

            try
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(validationErrorExpected);
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion
        
        #region IsValidRequest - RegistrationRequest

        [DataTestMethod]
        [DataRow("email", false, false)]        // happy path
        [DataRow(null, false, true)]            // null email
        [DataRow("", false, true)]              // empty email
        [DataRow(null, true, true)]             // null request
        public void IsValidRequest_RegistrationRequest_Tests
        (
            string email,
            bool nullRequest,
            bool validationErrorExpected
        )
        {
            RegistrationRequest request = null;

            if (!nullRequest)
            {
                request = new RegistrationRequest()
                {
                    Login = SetLoginRequest(),
                    EncodedEmail = email
                };
            }

            try
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(validationErrorExpected);
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion
        
        #region IsValidRequest - TokenRequest

        [DataTestMethod]
        [DataRow("userName", "token", false, false)]        // happy path
        [DataRow(null, "token", false, true)]               // null userName
        [DataRow("", "token", false, true)]                 // empty userName
        [DataRow("userName", null, false, true)]            // null token
        [DataRow("userName", "", false, true)]              // empty token
        [DataRow(null, null, true, true)]                   // null request
        public void IsValidRequest_TokenRequest_Tests
        (
            string userName,
            string token,
            bool nullRequest,
            bool validationErrorExpected
        )
        {
            TokenRequest request = null;

            if (!nullRequest)
            {
                request = SetTokenRequest(userName, token);
            }

            try
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(validationErrorExpected);
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion

        #region IsValidRequest - UpsertBucketListItemRequest

        [DataTestMethod]
        [DataRow(false, false)]        // happy path
        [DataRow(true, true)]          // null request
        public void IsValidRequest_UpsertBucketListItemRequest_Tests
        (
            bool nullRequest,
            bool validationErrorExpected
        )
        {
            UpsertBucketListItemRequest request = null;

            if (!nullRequest)
            {
                request = new UpsertBucketListItemRequest()
                {
                    BucketListItem = new Shared.dto.BucketListItem(),
                    Token = SetTokenRequest()
                };
            }

            try
            {
                sut.IsValidRequest(request);
                Assert.IsFalse(validationErrorExpected);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(validationErrorExpected);
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        #endregion

        #region Private methods

        private TokenRequest SetTokenRequest(string userName = "userName", string token = "token")
        {
            var login = new TokenRequest()
            {
                EncodedUserName = userName,
                EncodedToken = token
            };

            return login;
        }

        private LoginRequest SetLoginRequest(string userName = "userName", string password = "password")
        {
            var login = new LoginRequest() 
            { 
                EncodedUserName = userName, 
                EncodedPassword = password 
            };
            
            return login;
        }

        #endregion
    }
}
