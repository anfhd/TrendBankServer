using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository.Card
{
    public class CardRepository : RepositoryBase<Models.Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        { }

        public Models.Card GetCardForAll(Guid? id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();
        public IEnumerable<Models.Card> GetCards(Guid userId, bool trackChanges) =>
            FindByCondition(e => e.UserId.Equals(userId), trackChanges)
            .OrderBy(e => e.Number);

        public Models.Card GetCard(Guid userId, Guid? id, bool trackChanges) =>
            FindByCondition(C => C.UserId.Equals(userId) && C.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void CreateCardForUser(Guid userId, Models.Card card)
        {
            card.UserId = userId;
            Create(card);
        }

    }
}
