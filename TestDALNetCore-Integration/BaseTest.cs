using System;
using Shared.misc;
using dto = Shared.dto;

namespace TestDALNetCore_Integration
{
    public class BaseTest
    {
        protected dto.BucketListItem GetBucketListItem(string name = "I am a bucket list item")
        {
            var bucketListItem = new dto.BucketListItem
            {
                Name = name,
                Created = DateTime.Now,
                Category = Enums.BucketListItemTypes.Hot.ToString(),
                Achieved = false,
                Latitude = (decimal)81.12,
                Longitude = (decimal)41.34
            };

            return bucketListItem;
        }

        protected dto.User GetUser(string token)
        {
            var user = new dto.User()
            {
                UserName = "user",
                Salt = "salt",
                Password = "password",
                Email = "user@email.com",
                Token = token
            };

            return user;
        }
    }
}
