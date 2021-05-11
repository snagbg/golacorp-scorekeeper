using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Infrastructure.Repositories
{
    public interface IDocumentRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> specification);
        Task Save(T document);
        Task Update(T document, Expression<Func<T, bool>> specification);
    }
}
