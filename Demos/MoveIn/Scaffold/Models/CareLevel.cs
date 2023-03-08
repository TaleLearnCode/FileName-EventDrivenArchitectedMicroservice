using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CareLevel
    {
        public CareLevel()
        {
            CommunityCareLevels = new HashSet<CommunityCareLevel>();
        }

        public int CareLevelId { get; set; }
        public string? ExternalId { get; set; }
        public int CareTypeId { get; set; }
        public string CareLevelName { get; set; } = null!;
        public int? SortOrder { get; set; }
        public bool? AssignToNewCommunities { get; set; }
        public int RowStatusId { get; set; }

        public virtual CareType CareType { get; set; } = null!;
        public virtual ICollection<CommunityCareLevel> CommunityCareLevels { get; set; }
    }
}
