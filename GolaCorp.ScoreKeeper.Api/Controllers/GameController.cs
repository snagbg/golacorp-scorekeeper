using GolaCorp.ScoreKeeper.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Api.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GameController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
        [HttpPost]
        [Route("set-up-new-game")]
        public async Task<ActionResult<Guid>> SetUpNewGame(List<Guid> guids)
        {
            return await _gamesService.SetupNewGame(guids);
        }



    }
}
