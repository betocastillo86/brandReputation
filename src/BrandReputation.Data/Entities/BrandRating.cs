using System;
using System.Collections.Generic;

namespace BrandReputation.Web.Data
{
    public partial class BrandRating
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int Position { get; set; }
        public int Votes { get; set; }
        public decimal AvgRating { get; set; }
        public string RatingType { get; set; }
        public int EntityId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
