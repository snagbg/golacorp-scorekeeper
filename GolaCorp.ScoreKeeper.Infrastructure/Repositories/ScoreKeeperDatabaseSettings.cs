namespace GolaCorp.ScoreKeeper.Infrastructure.Repositories
{


    public class ScoreKeeperDatabaseSettings : IScoreKeeperDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IScoreKeeperDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
