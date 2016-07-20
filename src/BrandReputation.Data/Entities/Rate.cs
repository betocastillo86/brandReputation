using System;
using System.Collections.Generic;

namespace BrandReputation.Data
{
    public partial class Rate
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public byte Rating { get; set; }
        public DateTime CreationDateUtc { get; set; }
        public bool Deleted { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual User User { get; set; }
    }
}
