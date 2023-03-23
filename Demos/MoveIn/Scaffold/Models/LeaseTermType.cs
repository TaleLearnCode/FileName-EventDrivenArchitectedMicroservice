using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class LeaseTermType
    {
        public LeaseTermType()
        {
            LeaseTypes = new HashSet<LeaseType>();
        }

        public int LeaseTermTypeId { get; set; }
        public string LeaseTermTypeName { get; set; } = null!;

        public virtual ICollection<LeaseType> LeaseTypes { get; set; }
    }
}
