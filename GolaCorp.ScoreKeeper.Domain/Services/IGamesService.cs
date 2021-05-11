using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Domain.Services
{
    public interface IGamesService
    {
        Task<Guid> SetupNewGame(List<Guid> playerIds);
    }
}
