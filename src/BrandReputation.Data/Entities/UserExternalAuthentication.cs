using System;
using System.Collections.Generic;

namespace BrandReputation.Data
{
    public partial class UserExternalAuthentication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExternalAuthenticationTypeId { get; set; }
        public string UserKey { get; set; }

        public virtual User User { get; set; }
    }
}
