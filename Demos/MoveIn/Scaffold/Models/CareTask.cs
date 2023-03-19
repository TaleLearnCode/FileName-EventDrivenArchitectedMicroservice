using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareTask
    {
        public CareTask()
        {
            CareTaskResidents = new HashSet<CareTaskResident>();
        }

        public int CareTaskId { get; set; }
        public int CareTaskTypeId { get; set; }
        public int CareTaskStatusId { get; set; }
        public int? PrimaryEmployeeId { get; set; }
        public DateTime AssignedDateTime { get; set; }
        public DateTime ExpectedStartDateTime { get; set; }
        public DateTime ExpectetdEndDateTime { get; set; }
        public DateTime? ActualStartDateTime { get; set; }
        public DateTime? ActualEndDateTime { get; set; }

        public virtual CareTaskStatus CareTaskStatus { get; set; } = null!;
        public virtual CareTaskType CareTaskType { get; set; } = null!;
        public virtual Employee? PrimaryEmployee { get; set; }
        public virtual ICollection<CareTaskResident> CareTaskResidents { get; set; }
    }
}
