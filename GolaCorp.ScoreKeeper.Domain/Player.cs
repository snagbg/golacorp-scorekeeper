using System;

namespace GolaCorp.ScoreKeeper.Domain
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredDisplayName { get; set; }
    }
}
