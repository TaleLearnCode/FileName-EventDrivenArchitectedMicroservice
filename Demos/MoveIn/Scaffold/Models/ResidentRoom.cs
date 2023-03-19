using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class ResidentRoom
    {
        public int ResidentRoomId { get; set; }
        public int ResidentCommunityId { get; set; }
        public int RoomId { get; set; }
        public int CareTypeId { get; set; }

        public virtual CareType CareType { get; set; } = null!;
        public virtual ResidentCommunity ResidentCommunity { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
