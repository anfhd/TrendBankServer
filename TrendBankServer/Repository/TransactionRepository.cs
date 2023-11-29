using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public class TransactionRepository : RepositoryBase<Models.Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }

}
