using System;
using System.Collections.Generic;

namespace BrandReputation.Web.Data
{
    public partial class BrandType
    {
        public BrandType()
        {
            BrandTypeBrand = new HashSet<BrandTypeBrand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BrandTypeBrand> BrandTypeBrand { get; set; }
    }
}
