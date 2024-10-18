using System;
using System.Collections.Generic;

namespace ASM02_ShoppingWebsite.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
