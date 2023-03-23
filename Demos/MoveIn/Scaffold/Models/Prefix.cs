using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class Prefix
    {
        public int PrefixId { get; set; }
        public string PrefixValue { get; set; } = null!;
        public int? SortOrder { get; set; }
        public int RowStatusId { get; set; }
    }
}
