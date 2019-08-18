using System;
using System.Collections.Generic;

namespace DALNetCore.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
