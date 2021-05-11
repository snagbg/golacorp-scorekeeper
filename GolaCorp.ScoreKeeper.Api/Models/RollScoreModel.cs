using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Api.Models
{
    public abstract class RollScoreModelBase
    {
        public ushort FrameNumber { get; set; }
        public ushort NumberOfPinsKnockedDown { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }

    public class RollOneScoreModel : RollScoreModelBase
    {
        public bool WasStrike { get; set; }
    }

    public class RollTwoScoreModel : RollScoreModelBase
    {
        public bool WasSpare { get; set; }
    }




}
