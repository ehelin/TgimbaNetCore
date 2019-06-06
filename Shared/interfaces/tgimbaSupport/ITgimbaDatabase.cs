using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.interfaces
{
    public interface ITgimbaDatabase
    {
        void SaveWebsiteStatus(bool websiteIsUp);
    }
}
