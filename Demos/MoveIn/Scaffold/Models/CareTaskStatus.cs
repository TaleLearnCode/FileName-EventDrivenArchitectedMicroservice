using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareTaskStatus
    {
        public int CareTaskStatusId { get; set; }
        public string CareTaskStatusName { get; set; } = null!;
        public bool IsDefault { get; set; }
        public int RowStatusId { get; set; }
    }
}
