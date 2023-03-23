using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class ResponsibleParty
    {
        public ResponsibleParty()
        {
            Residents = new HashSet<Resident>();
        }

        public int ResponsiblePartyId { get; set; }
        public string? ExternalId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? EmailAddress { get; set; }

        public virtual ICollection<Resident> Residents { get; set; }
    }
}
