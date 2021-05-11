﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
