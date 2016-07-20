using System;
using System.Collections.Generic;

namespace BrandReputation.Data
{
    public partial class Location
    {
        public Location()
        {
            Brand = new HashSet<Brand>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentLocationId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual Location ParentLocation { get; set; }
        public virtual ICollection<Location> InverseParentLocation { get; set; }
    }
}
