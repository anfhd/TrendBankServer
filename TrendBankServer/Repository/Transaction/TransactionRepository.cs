using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository.Transaction
{
    public class TransactionRepository : RepositoryBase<Models.Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        { }
        public IEnumerable<Models.Transaction> GetTransactions(Guid cardId, bool trackChanges) =>
            FindByCondition(e => e.CardFromId.Equals(cardId), trackChanges);
        public Models.Transaction GetTransaction(Guid cardId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CardFromId.Equals(cardId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }

}
