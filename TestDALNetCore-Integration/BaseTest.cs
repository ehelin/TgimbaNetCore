using System;
using System.Linq;
using DALNetCore;
using Shared.misc;
using dto = Shared.dto;

namespace TestDALNetCore_Integration
{
    public class BaseTest
    {
        protected string UserName = "user";
        protected string Token = "token";

        protected void RemoveTestUser() 
        {
            var dbContext = GetDbContext();

            var user = dbContext.User.Where(x => x.UserName == this.UserName)
                                        .FirstOrDefault();

            if (user != null)
            {
                var dbBucketListItems = from bli in dbContext.BucketListItem
                                        join blu in dbContext.BucketListUser on bli.BucketListItemId equals blu.BucketListItemId
                                        join u in dbContext.User on blu.UserId equals u.UserId
                                        where u.UserName == this.UserName
                                        select bli;

                foreach(var dbBucketListItem in dbBucketListItems)
                {
                    var dbBucketListUser = dbContext.BucketListUser
                                                    .Where(x => x.BucketListItemId == dbBucketListItem.BucketListItemId)
                                                    .FirstOrDefault();

                    dbContext.BucketListUser.Remove(dbBucketListUser);
                    dbContext.BucketListItem.Remove(dbBucketListItem);
                    dbContext.SaveChanges();
                }

                dbContext.User.Remove(user);
                dbContext.SaveChanges();
            }
        }

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

        protected BucketListContext GetDbContext()
        {
            var dbContext = new BucketListContext();

            return dbContext;
        }

        protected dto.User GetUser(string token)
        {
            var user = new dto.User()
            {
                UserName = this.UserName,
                Salt = "salt",
                Password = this.Token,
                Email = "user@email.com",
                Token = token
            };

            return user;
        }
    }
}
