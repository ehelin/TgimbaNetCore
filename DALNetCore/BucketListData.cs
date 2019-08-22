using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.interfaces;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DALNetCore.Models;
using Shared.misc;

namespace DALNetCore
{
    public class BucketListData : IBucketListData
    {
        private DbContext context = null;

        public BucketListData(DbContext context) {
            this.context = context;
        }

        public void AddToken(string userName, string token)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string userName, string email, string passWord, string salt)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBucketListItem(int bucketListItemDbId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string userName, string passWord, string email)
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

        public bool UpsertBucketListItem(Shared.dto.BucketListItem bucketListItems)
        {
            throw new NotImplementedException();
        }
    }
}
