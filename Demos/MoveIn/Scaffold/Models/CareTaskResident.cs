using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareTaskResident
    {
        public int CareTaskResidentId { get; set; }
        public int CareTaskId { get; set; }
        public int ResidentId { get; set; }

        public virtual CareTask CareTask { get; set; } = null!;
        public virtual Resident Resident { get; set; } = null!;
    }
}
