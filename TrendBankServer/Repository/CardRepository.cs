using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public class CardRepository : RepositoryBase<Models.Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }

}
