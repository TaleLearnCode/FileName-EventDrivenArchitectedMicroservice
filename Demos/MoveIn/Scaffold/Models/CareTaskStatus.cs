using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareTaskStatus
    {
        public CareTaskStatus()
        {
            CareTasks = new HashSet<CareTask>();
        }

        public int CareTaskStatusId { get; set; }
        public string CareTaskStatusName { get; set; } = null!;
        public bool IsDefault { get; set; }
        public int RowStatusId { get; set; }

        public virtual ICollection<CareTask> CareTasks { get; set; }
    }
}
