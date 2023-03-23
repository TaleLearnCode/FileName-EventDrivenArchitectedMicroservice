using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class Suffix
    {
        public int SuffixId { get; set; }
        public string SuffixValue { get; set; } = null!;
        public int? SortOrder { get; set; }
        public int RowStatusId { get; set; }
    }
}
