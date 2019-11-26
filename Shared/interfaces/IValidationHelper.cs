using Shared.dto.api;

namespace Shared.interfaces
{
    public interface IValidationHelper
    {
        void IsValidRequest(UpsertBucketListItemRequest request);
        void IsValidRequest(DeleteBucketListItemRequest request);
        void IsValidRequest(GetBucketListItemRequest request);
        void IsValidRequest(TokenRequest request);
        void IsValidRequest(LoginRequest request);
        void IsValidRequest(RegistrationRequest request);
    }
}
