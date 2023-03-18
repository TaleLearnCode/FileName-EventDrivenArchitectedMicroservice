using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CommunityAncillaryCare
    {
        public int CommunityAncillaryCareId { get; set; }
        public string? ExternalId { get; set; }
        public int CommunityId { get; set; }
        public int AncillaryCareId { get; set; }
        public int? AssessmentScoreMinimum { get; set; }
        public int? AssessmentScoreMaximum { get; set; }
        public decimal? BaseRate { get; set; }
        public decimal? DailyRate { get; set; }

        public virtual AncillaryCare AncillaryCare { get; set; } = null!;
        public virtual Community Community { get; set; } = null!;
    }
}
