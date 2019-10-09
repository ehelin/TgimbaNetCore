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
        protected ITgimbaService service { get; set; }
        protected Mock<IBucketListData> mockBucketListData { get; set; }
        protected Mock<IPassword> mockPassword { get; set; }
        protected Mock<IGenerator> mockGenerator { get; set; }

        public BaseTest()
        {
            this.mockBucketListData = new Mock<IBucketListData>();
            this.mockPassword = new Mock<IPassword>();
            this.mockGenerator = new Mock<IGenerator>();
            this.service = new TgimbaService(this.mockBucketListData.Object, mockPassword.Object, mockGenerator.Object);
        }
    }
}
