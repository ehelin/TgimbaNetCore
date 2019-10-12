using APINetCore;
using Moq;
using Shared.interfaces;
using Shared.dto;

namespace TestAPINetCore_Unit
{
    public class BaseTest
    {
        protected ITgimbaService service { get; set; }
        protected Mock<IBucketListData> mockBucketListData { get; set; }
        protected Mock<IPassword> mockPassword { get; set; }
        protected Mock<IGenerator> mockGenerator { get; set; }

        public BaseTest()
        {
            this.mockBucketListData = new Mock<IBucketListData>();
            this.mockPassword = new Mock<IPassword>();
            this.mockGenerator = new Mock<IGenerator>();
            this.service = new TgimbaService(this.mockBucketListData.Object, mockPassword.Object, mockGenerator.Object);
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
    }
}
