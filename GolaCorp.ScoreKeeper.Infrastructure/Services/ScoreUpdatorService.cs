using GolaCorp.ScoreKeeper.Domain;
using GolaCorp.ScoreKeeper.Domain.Services;
using GolaCorp.ScoreKeeper.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Infrastructure.Services
{
    public class ScoreUpdatorService : IScoreUpdatorService
    {
        private readonly IDocumentRepository<Game> _documentRepository;

        public ScoreUpdatorService(IDocumentRepository<Game> documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task UpdateRollOneScore(RollOneScore rollOneScore)
        {
            var game = await _documentRepository.Get(x => x.GameId == rollOneScore.GameId);
            game.UpdateRollOneScore(rollOneScore);
            await _documentRepository.Update(game, x => x.GameId == rollOneScore.GameId);
        }

        public async Task UpdateRollTwoScore(RollTwoScore rollTwoScore)
        {
            var game = await _documentRepository.Get(x => x.GameId == rollTwoScore.GameId);
            game.UpdateRollTwoScore(rollTwoScore);
            await _documentRepository.Update(game, x => x.GameId == rollTwoScore.GameId);
        }
    }
}
