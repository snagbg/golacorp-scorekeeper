using System;

namespace GolaCorp.ScoreKeeper.Domain
{
    public abstract class RollScoreBase
    {
        public ushort FrameNumber { get; set; }
        public ushort NumberOfPinsKnockedDown { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }

    public class RollOneScore : RollScoreBase
    {
        public bool WasStrike { get; set; }
    }

    public class RollTwoScore : RollScoreBase
    {
        public bool WasSpare { get; set; }
    }




}
