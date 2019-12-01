using System;
using Shared.dto.api;
using Shared.interfaces;

namespace HttpAPINetCore.helpers
{
    public class ValidationHelper : IValidationHelper
    {
        public void IsValidRequest(DeleteBucketListItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }

            IsValidRequest(request.Token);

            if (request.BucketListItemId <= 0)
            {
                throw new ArgumentNullException("BucketListItemId is less than zero");
            }
        }

        public void IsValidRequest(GetBucketListItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }
            
            this.IsValidRequest(request.Token);
        }

        public void IsValidRequest(LoginRequest request)
        {   
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }
            else if (string.IsNullOrEmpty(request.EncodedUserName))
            {
                throw new ArgumentNullException("EncodedUserName is null or empty");
            }
            else if (string.IsNullOrEmpty(request.EncodedPassword))
            {
                throw new ArgumentNullException("EncodedPassword is null or empty");
            }
        }

        public void IsValidRequest(RegistrationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }
            else if (string.IsNullOrEmpty(request.EncodedEmail))
            {
                throw new ArgumentNullException("EncodedEmail is null or empty");
            }

            this.IsValidRequest(request.Login);
        }

        public void IsValidRequest(TokenRequest request)
        {           
            if (request == null)
            {
                throw new ArgumentNullException("requesty is null");
            }
            else if (string.IsNullOrEmpty(request.EncodedUserName))
            {
                throw new ArgumentNullException("EncodedUserName is null or empty");
            }
            else if (string.IsNullOrEmpty(request.EncodedToken))
            {
                throw new ArgumentNullException("EncodedToken is null or empty");
            }
        }

        public void IsValidRequest(UpsertBucketListItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request is null");
            }

            this.IsValidRequest(request.Token);
        }
    }
}
