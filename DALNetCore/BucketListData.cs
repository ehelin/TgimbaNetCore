using System;
using System.Collections.Generic;
using System.Linq;
using DALNetCore.interfaces;
using Shared.dto;
using Shared.exceptions;
using Shared.interfaces;
using models = DALNetCore.Models;

namespace DALNetCore
{
    public class BucketListData : IBucketListData
    {
        private BucketListContext context = null;
        private IUserHelper userHelper = null;

        public BucketListData(BucketListContext context, IUserHelper userHelper)
        {
            this.userHelper = userHelper;
            this.context = context;
        }

        #region User 

        public void AddToken(int userId, string token)
        {
            var dbUser = this.context.User
                                   .Where(x => x.UserId == userId)
                                   .FirstOrDefault();
            if (dbUser == null)
            {
                throw new RecordDoesNotExistException("AddToken - User to have token added does not exist. userId - " + userId.ToString());
            }

            dbUser.Token = token;

            this.context.Update(dbUser);
            this.context.SaveChanges();
        }

        public User GetUser(int id)
        {
            var dbUser = this.context.User
                                   .Where(x => x.UserId == id)
                                   .FirstOrDefault();
            if (dbUser == null)
            {
                throw new RecordDoesNotExistException("GetUser - User does not exist. userId - " + id.ToString());
            }

            var user = this.userHelper.ConvertDbUserToUser(dbUser);

            return user;
        }

        public User GetUser(string userName)
        {
            var dbUser = this.context.User
                            .Where(x => x.UserName == userName)
                            .FirstOrDefault();

            var user = this.userHelper.ConvertDbUserToUser(dbUser);
          
            return user;
        }

        public int AddUser(User user)
        {
            var dbUser = new models.User
            {
                UserName = user.UserName,
                Email = user.Email,
                PassWord = user.Password,
                Salt = user.Salt,
                Created = DateTime.Now.ToUniversalTime(),
                CreatedBy = "Website",
                Modified = DateTime.Now.ToUniversalTime(),
                ModifiedBy = "Website"
            };
            this.context.User.Add(dbUser);
            this.context.SaveChanges();

            return dbUser.UserId;
        }

        public void DeleteUser(int userId)
        {
            var dbUser = this.context.User
                                   .Where(x => x.UserId == userId)
                                   .FirstOrDefault(); 
            if (dbUser == null)
            {
                throw new RecordDoesNotExistException("DeleteUser - User to delete does not exist. userId - " + userId.ToString());
            }

            this.context.Remove(dbUser);
            this.context.SaveChanges();
        }

        #endregion

        #region Misc

        public void LogMsg(string msg)
        {
            var logModel = new models.Log
            {
                LogMessage = msg,
                Created = DateTime.UtcNow
            };
            this.context.Log.Add(logModel);
            this.context.SaveChanges();
        }

        public IList<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            var buildStatistics = this.context.BuildStatistics
                                    .OrderByDescending(s => s.Start)
                                    .Take(2)
                                    .ToList();
            var systemBuildStatics = new List<SystemBuildStatistic>();

            if (buildStatistics != null)
            {
                foreach (var buildStatistic in buildStatistics)
                {
                    var systemBuildStatistic = new SystemBuildStatistic
                    {
                        Start = buildStatistic.Start.ToString(),
                        End = buildStatistic.End.ToString(),
                        BuildNumber = buildStatistic.BuildNumber,
                        Status = buildStatistic.Status
                    };

                    systemBuildStatics.Add(systemBuildStatistic);
                }
            }

            return systemBuildStatics;
        }

        public IList<SystemStatistic> GetSystemStatistics()
        {
            var systemStatistics = this.context.SystemStatistics
                                    .OrderByDescending(s => s.Created)
                                    .Take(2)
                                    .ToList();
            var systemSystemStatics = new List<SystemStatistic>();

            if (systemStatistics != null)
            {
                foreach (var systemStatistic in systemStatistics)
                {
                    var systemSystemStatistic = new SystemStatistic
                    {
                        WebSiteIsUp = systemStatistic.WebsiteIsUp,
                        DatabaseIsUp = systemStatistic.DatabaseIsUp,
                        AzureFunctionIsUp = systemStatistic.AzureFunctionIsUp,
                        Created = systemStatistic.Created.ToString()
                    };

                    systemSystemStatics.Add(systemSystemStatistic);
                }
            }

            return systemSystemStatics;
        }

        #endregion

        #region BucketList

        public void UpsertBucketListItem(Shared.dto.BucketListItem bucketListItem, string userName)
        {
            var existingBucketListItem = this.context.BucketListItem
                                                            .Where(x => x.BucketListItemId == bucketListItem.Id)
                                                            .FirstOrDefault();

            if (existingBucketListItem != null)
            {
                UpdateBucketListItem(existingBucketListItem, bucketListItem);
            }
            else
            {
                InsertBucketListItem(bucketListItem, userName);
            }
        }

        public IList<Shared.dto.BucketListItem> GetBucketList
        (
            string userName, 
            string srchTerm = ""
        )
        {
            var dbBucketListItems = from bli in this.context.BucketListItem
                                    join blu in this.context.BucketListUser on bli.BucketListItemId equals blu.BucketListItemId
                                    join u in this.context.User on blu.UserId equals u.UserId
                                    where u.UserName == userName
                                    select bli;

            if (!string.IsNullOrEmpty(srchTerm))
            {
                dbBucketListItems = Search(dbBucketListItems, srchTerm);
            }

            var bucketListItems = new List<Shared.dto.BucketListItem>();
            foreach (var dbBucketListItem in dbBucketListItems)
            {
                var bucketListItem = new Shared.dto.BucketListItem
                {
                    Name = dbBucketListItem.ListItemName.Trim(),
                    Created = dbBucketListItem.Created.Value.ToLocalTime(),
                    Category = dbBucketListItem.Category,
                    Achieved = dbBucketListItem.Achieved.HasValue
                                    ? dbBucketListItem.Achieved.Value : false,
                    Id = dbBucketListItem.BucketListItemId,
                    Latitude = dbBucketListItem.Latitude.HasValue ? (decimal)dbBucketListItem.Latitude : (decimal)0,
                    Longitude = dbBucketListItem.Longitude.HasValue ? (decimal)dbBucketListItem.Longitude : (decimal)0
                };

                bucketListItems.Add(bucketListItem);
            }

            return bucketListItems;
        }

        public void DeleteBucketListItem(int bucketListItemDbId)
        {
            var bucketListItemToDelete = this.context.BucketListItem
                                                        .Where(x => x.BucketListItemId == bucketListItemDbId)
                                                        .FirstOrDefault();
            var bucketListItemUserToDelete = this.context.BucketListUser
                                                        .Where(x => x.BucketListItemId == bucketListItemDbId)
                                                        .FirstOrDefault();

            if (bucketListItemToDelete == null)
            {
                throw new RecordDoesNotExistException("Bucket list item to be deleted does not exist - id: " + bucketListItemDbId.ToString());
            }

            this.context.BucketListUser.Remove(bucketListItemUserToDelete);
            this.context.BucketListItem.Remove(bucketListItemToDelete);
            this.context.SaveChanges();
        }

        #endregion

        #region Private Methods

        private void UpdateBucketListItem
        (
            models.BucketListItem existingBucketListItem,
            Shared.dto.BucketListItem bucketListItem
        )
        {
            existingBucketListItem.ListItemName = bucketListItem.Name;
            existingBucketListItem.Created = bucketListItem.Created.ToUniversalTime();
            existingBucketListItem.Category = bucketListItem.Category;
            existingBucketListItem.Achieved = bucketListItem.Achieved;
            existingBucketListItem.Latitude = bucketListItem.Latitude;
            existingBucketListItem.Longitude = bucketListItem.Longitude;

            this.context.Update(existingBucketListItem);
            this.context.SaveChanges();
        }

        private void InsertBucketListItem(Shared.dto.BucketListItem bucketListItem, string userName)
        {
            var user = this.context.User
                                .Where(x => x.UserName == userName)
                                .FirstOrDefault();

            if (user == null)
            {
                throw new RecordDoesNotExistException("InsertBucketListItem - User does not exist. UserName: " + userName);
            }

            var bucketListItemToSave = new models.BucketListItem
            {
                ListItemName = bucketListItem.Name,
                Created = bucketListItem.Created.ToUniversalTime(),
                Category = bucketListItem.Category,
                Achieved = bucketListItem.Achieved,
                Latitude = bucketListItem.Latitude,
                Longitude = bucketListItem.Longitude
            };

            this.context.BucketListItem.Add(bucketListItemToSave);
            this.context.SaveChanges();

            var bucketListItemUser = new models.BucketListUser
            {
                BucketListItemId = bucketListItemToSave.BucketListItemId,
                UserId = user.UserId
            };

            this.context.BucketListUser.Add(bucketListItemUser);
            this.context.SaveChanges();
        }

        private IQueryable<models.BucketListItem> Search(IQueryable<models.BucketListItem> bucketListItems, string srchTerm)
        {
            IQueryable<models.BucketListItem> searchedBucketListItems = bucketListItems
                                                                              .Where(x => x.ListItemName.Contains(srchTerm));

            return searchedBucketListItems;
        }

        #endregion
    }
}
