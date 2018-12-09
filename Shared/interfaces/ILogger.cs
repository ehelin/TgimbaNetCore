using System;
using System.Collections.Generic;
using System.Text;
using Shared.misc;

namespace Shared.interfaces
{
    public interface ILogger
    {
        void Log(string msg, Enums.LogLevel level);
    }
}
