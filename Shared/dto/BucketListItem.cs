using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.dto
{
    public class BucketListItem
    {
        //HACKs
        private string ONE = "1";
        private string ZERO = "0";

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Category { get; set; }
        public bool Achieved { get; set; }
        public int? Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string GetIntStringAchievedValue()
        {
            if (this.Achieved)
                return ONE;
            else
                return ZERO;
        }
    }
}
