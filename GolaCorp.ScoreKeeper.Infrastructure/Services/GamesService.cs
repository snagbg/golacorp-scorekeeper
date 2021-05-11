using GolaCorp.ScoreKeeper.Domain;
using GolaCorp.ScoreKeeper.Domain.Services;
using GolaCorp.ScoreKeeper.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Infrastructure.Services
{
    public class GamesService : IGamesService
    {
        private readonly IDocumentRepository<Game> _documentRepository;

        public GamesService(IDocumentRepository<Game> documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<Guid> SetupNewGame(List<Guid> playerIds)
        {
            var newGame = new Game()
            {
                GameId = Guid.NewGuid(),                
                
            };

            foreach(var playerId in playerIds)
            {
                var shortName = playerId.ToString().Substring(0, 4);
                newGame.Players.Add(new Player() { 
                    PlayerId = playerId, 
                    FirstName = $"{shortName}First",
                    LastName = $"{shortName}Last",
                    PreferredDisplayName = $"{shortName}DisplayName"
                });             
            }

            await  _documentRepository.Save(newGame);

            return newGame.GameId;
        }
    }
}
