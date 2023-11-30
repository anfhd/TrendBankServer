using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public class CardRepository : RepositoryBase<Models.Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        { }
        public IEnumerable<Models.Card> GetCards(Guid userId, bool trackChanges) =>
            FindByCondition(e => e.UserId.Equals(userId), trackChanges)
            .OrderBy(e => e.Number);

        public Models.Card GetCard(Guid userId, Guid id, bool trackChanges) =>
            FindByCondition(C => C.UserId.Equals(userId) && C.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    }
}
