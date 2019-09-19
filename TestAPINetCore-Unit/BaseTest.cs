using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Shared.interfaces;
using APINetCore;

namespace TestAPINetCore_Unit
{
    public class BaseTest
    {
        protected Mock<IBucketListData> mockBucketListData { get; set; }
        protected ITgimbaService service { get; set; }

        public BaseTest()
        {
            this.mockBucketListData = new Mock<IBucketListData>();
            this.service = new TgimbaService(this.mockBucketListData.Object);
        }
    }
}
