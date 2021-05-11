using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Domain.Services
{
    public interface IScoreUpdatorService
    {
        Task UpdateRollOneScore(RollOneScore rollOneScore);
        Task UpdateRollTwoScore(RollTwoScore rollTwoScore);
    }
}
