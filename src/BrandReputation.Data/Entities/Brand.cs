using System;
using System.Collections.Generic;

namespace BrandReputation.Web.Data
{
    public partial class Brand
    {
        public Brand()
        {
            BrandAttribute = new HashSet<BrandAttribute>();
            BrandRating = new HashSet<BrandRating>();
            BrandTypeBrand = new HashSet<BrandTypeBrand>();
            Rate = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreationDateUtc { get; set; }
        public DateTime? ModifiedDateUtc { get; set; }
        public int UserId { get; set; }
        public decimal AvgRating { get; set; }

        public virtual ICollection<BrandAttribute> BrandAttribute { get; set; }
        public virtual ICollection<BrandRating> BrandRating { get; set; }
        public virtual ICollection<BrandTypeBrand> BrandTypeBrand { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }
        public virtual Location Country { get; set; }
        public virtual User User { get; set; }
    }
}
