using System;
using System.Collections.Generic;

namespace BrandReputation.Data
{
    public partial class User
    {
        public User()
        {
            Brand = new HashSet<Brand>();
            Rate = new HashSet<Rate>();
            UserExternalAuthentication = new HashSet<UserExternalAuthentication>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public DateTime CreationDateUtc { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }
        public virtual ICollection<UserExternalAuthentication> UserExternalAuthentication { get; set; }
        public virtual Location Country { get; set; }
    }
}
