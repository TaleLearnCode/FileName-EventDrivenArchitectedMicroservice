using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class CommunityCareLevel
    {
        public int CommunityCareLevelId { get; set; }
        public int CommunityId { get; set; }
        public int CareLevelId { get; set; }
        public int? AssessmentScoreMinimum { get; set; }
        public int? AssessmentScoreMaximum { get; set; }
        public int? AssessmentTimeMinimum { get; set; }
        public int? AssessmentTimeMaximum { get; set; }
        public decimal? BaseRate { get; set; }
        public decimal? DailyRate { get; set; }

        public virtual CareLevel CareLevel { get; set; } = null!;
        public virtual Community Community { get; set; } = null!;
    }
}
