using System;
using System.Collections.Generic;

namespace BrandReputation.Web.Data
{
    public partial class BrandAttribute
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
