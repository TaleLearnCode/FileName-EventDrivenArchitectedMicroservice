using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class AncillaryCare
    {
        public AncillaryCare()
        {
            CommunityAncillaryCares = new HashSet<CommunityAncillaryCare>();
        }

        public int AncillaryCareId { get; set; }
        public string ExternalId { get; set; } = null!;
        public int AncillaryCareCategoryId { get; set; }
        public string AncillaryCareName { get; set; } = null!;
        public string? ForegroundColor { get; set; }
        public string? BackgroundColor { get; set; }
        public bool AssignToNewCommunities { get; set; }
        public int? SortOrder { get; set; }
        public int RowStatusId { get; set; }

        public virtual AncillaryCareCategory AncillaryCareCategory { get; set; } = null!;
        public virtual ICollection<CommunityAncillaryCare> CommunityAncillaryCares { get; set; }
    }
}
