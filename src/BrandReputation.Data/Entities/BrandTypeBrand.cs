using System;
using System.Collections.Generic;

namespace BrandReputation.Data
{
    public partial class BrandTypeBrand
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BrandTypeId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual BrandType BrandType { get; set; }
    }
}
