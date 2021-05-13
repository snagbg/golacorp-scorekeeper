using GolaCorp.ScoreKeeper.Api.Models;
using GolaCorp.ScoreKeeper.Domain;
using GolaCorp.ScoreKeeper.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Api.Controllers
{
    [Route("player-score")]
    [ApiController]
    public class PlayerScoreController : ControllerBase
    {
        private readonly IScoreUpdatorService _scoreUpdatorService;

        public PlayerScoreController(IScoreUpdatorService scoreUpdatorService)
        {
            _scoreUpdatorService = scoreUpdatorService;
        }
        [HttpPost]
        [Route("update-roll-one")]
        public async Task UpdateRollOne(RollOneScoreModel rollOneScoreInput)
        {
            RollOneScore rollOneScore = MapRollOneScore(rollOneScoreInput);

            await _scoreUpdatorService.UpdateRollOneScore(rollOneScore);
        }

        [HttpPost]
        [Route("update-roll-two")]
        public async Task UpdateRollTwo(RollTwoScoreModel rollTwoScoreInput)
        {
            RollTwoScore rollOneScore = MapRollTwoScore(rollTwoScoreInput);

            await _scoreUpdatorService.UpdateRollTwoScore(rollOneScore);
        }

        private static RollOneScore MapRollOneScore(RollOneScoreModel rollOneScoreInput)
        {
            return new RollOneScore()
            {
                FrameNumber = rollOneScoreInput.FrameNumber,
                GameId = rollOneScoreInput.GameId,
                NumberOfPinsKnockedDown = rollOneScoreInput.NumberOfPinsKnockedDown,
                PlayerId = rollOneScoreInput.PlayerId,
                WasStrike = rollOneScoreInput.WasStrike
            };
        }

        private static RollTwoScore MapRollTwoScore(RollTwoScoreModel rollTwoScoreInput)
        {
            return new RollTwoScore()
            {
                FrameNumber = rollTwoScoreInput.FrameNumber,
                GameId = rollTwoScoreInput.GameId,
                NumberOfPinsKnockedDown = rollTwoScoreInput.NumberOfPinsKnockedDown,
                PlayerId = rollTwoScoreInput.PlayerId,
                WasSpare = rollTwoScoreInput.WasSpare
            };
        }
    }
}
