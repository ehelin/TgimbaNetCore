using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using models = DALNetCore.Models;
using System.Linq;
using Shared.misc;

namespace DALNetCore
{
    public class BucketListData : IBucketListData
    {
        private BucketListContext context = null;

        public BucketListData(BucketListContext context) {
            this.context = context;
        }

        public void AddToken(string userName, string token)
        {
            // TODO - switch to id
            var user = this.context.User
                                    .Where(x => x.UserName == userName)
                                    .FirstOrDefault();
            user.Token = token;
            this.context.Update(user);
            this.context.SaveChanges();
        }

        public void AddUser(string userName, string email, string passWord, string salt)
        {
            var user = new models.User
            {
                UserName = userName,
                Email = email,
                PassWord = passWord,
                Salt = salt
            };
            this.context.User.Add(user);
            this.context.SaveChanges();
        }

        public void DeleteBucketListItem(int bucketListItemDbId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userName, string passWord, string email)
        {
            throw new NotImplementedException();
        }

        public IList<Shared.dto.BucketListItem> GetBucketList(string userName, string sortString, string srchTerm = "")
        {
            throw new NotImplementedException();
        }

        public IList<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            throw new NotImplementedException();
        }

        public IList<SystemStatistic> GetSystemStatistics()
        {
            throw new NotImplementedException();
        }

        public Shared.dto.User GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void LogMsg(string msg)
        {
            throw new NotImplementedException();
        }

        public void UpsertBucketListItem(Shared.dto.BucketListItem bucketListItems)
        {
            throw new NotImplementedException();
        }
    }
}
