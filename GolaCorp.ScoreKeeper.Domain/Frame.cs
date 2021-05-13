using System;
using System.Collections.Generic;

namespace GolaCorp.ScoreKeeper.Domain
{
    public class Frame
    {
        public Guid FrameId { get; set; }
        public ushort FrameNumber { get; set; }
        public List<PlayerScore> Scores { get; set; } = new List<PlayerScore>();

    }
}
