using System;

namespace GolaCorp.ScoreKeeper.Domain
{
    public class PlayerScore
    {
        public Guid PlayerScoreId { get; set; }
        public Guid PlayerId { get; set; }
        public FirstRoll FirstRoll { get; set; } = new FirstRoll();
        public SecondRoll SecondRoll { get; set; } = new SecondRoll();
        public int TotalPoints { get; set; }

    }
}
