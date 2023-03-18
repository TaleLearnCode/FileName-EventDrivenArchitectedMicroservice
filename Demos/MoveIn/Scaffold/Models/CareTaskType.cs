using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareTaskType
    {
        public int CareTaskTypeId { get; set; }
        public string CareTaskTypeName { get; set; } = null!;
        public int EmployeeRoleId { get; set; }
        public bool AssignToNewResidents { get; set; }
        public int RowStatusId { get; set; }
    }
}
