using GolaCorp.ScoreKeeper.Domain;
using GolaCorp.ScoreKeeper.Domain.Services;
using GolaCorp.ScoreKeeper.Infrastructure.Repositories;
using GolaCorp.ScoreKeeper.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async  Task<ActionResult<Guid>> SetUpNewGame(List<Guid> guids)
        {
            return await _gamesService.SetupNewGame(guids);
        }

       

    }
}
