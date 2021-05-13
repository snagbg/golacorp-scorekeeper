namespace GolaCorp.ScoreKeeper.Domain
{
    public class Roll
    {
        public int Points { get; set; }
    }

    public class FirstRoll : Roll
    {
        public bool WasStrike { get; set; }

    }

    public class SecondRoll : Roll
    {
        public bool WasSpare { get; set; }
    }


}
