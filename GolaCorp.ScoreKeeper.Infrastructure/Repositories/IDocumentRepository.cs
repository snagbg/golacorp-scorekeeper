using System;
using System.Linq.Expressions;
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
