using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Domain
{
    public class Frame
    {
        public Guid FrameId { get; set; }
        public ushort FrameNumber { get; set; }
        public List<PlayerScore> Scores { get; set; } = new List<PlayerScore>();

    }
}
