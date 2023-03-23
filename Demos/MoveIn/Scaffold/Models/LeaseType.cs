using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class LeaseType
    {
        public LeaseType()
        {
            Leases = new HashSet<Lease>();
        }

        public int LeaseTypeId { get; set; }
        public string? ExternalId { get; set; }
        public int LeaseTermTypeId { get; set; }
        public string LeaseTypeName { get; set; } = null!;
        public int RowStatusId { get; set; }

        public virtual LeaseTermType LeaseTermType { get; set; } = null!;
        public virtual ICollection<Lease> Leases { get; set; }
    }
}
