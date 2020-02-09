using System;
using System.Linq;
using DALNetCore;
using Shared.misc;
using DALNetCore.interfaces;
using DALNetCore.helpers;
using dto = Shared.dto;
using models = DALNetCore.Models;

namespace TestDALNetCore_Integration
{
    public class BaseTest
    {
        protected string UserName = "user";
        protected string Password = "password";
        protected string Token = "token";
        protected IUserHelper userHelper = new UserHelper();

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
            var dbContext = new BucketListContext(true);

            return dbContext;
        }

        protected models.User GetDbUser(string token)
        {
            var user = new models.User()
            {
                UserName = this.UserName,
                Salt = "salt",
                PassWord = this.Password,
                Email = "user@email.com",
                Token = token
            };

            return user;
        }

        protected dto.User GetUser(string token)
        {
            var user = new dto.User()
            {
                UserName = this.UserName,
                Salt = "salt",
                Password = this.Password,
                Email = "user@email.com",
                Token = token
            };

            return user;
        }
    }
}
