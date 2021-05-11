using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GolaCorp.ScoreKeeper.Infrastructure.Repositories
{
    public class DocumentRepository<T> : IDocumentRepository<T>
    {
        private readonly IMongoDatabase _mongoDatabase;

        public DocumentRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public Task<T> Get(Expression<Func<T, bool>> specification)
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name).Find(specification).SingleAsync();
        }

        public Task Save(T document)
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name).InsertOneAsync(document);
        }

        public Task Update(T document, Expression<Func<T, bool>> specification)
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name).ReplaceOneAsync<T>(specification, document, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
