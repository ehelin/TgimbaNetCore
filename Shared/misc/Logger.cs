using System;
using System.Collections.Generic;
using System.Text;
using Shared.interfaces;
using Shared.misc;

namespace Shared.misc
{
    public class Logger : ILogger
    {
        private IBucketListData_Old db = null;
        private Enums.LogLevel level;

        public Logger(IBucketListData_Old db, Enums.LogLevel level)
        {
            this.db = db;
            this.level = level;
        }

        public void Log(string msg, Enums.LogLevel level)
        {
            if (level <= this.level)
            {
                db.LogMsg(msg);
            }
        }
    }
}
