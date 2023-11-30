namespace TrendBankServer.Repository.Card
{
    public interface ICardRepository
    {
        Models.Card GetCardForAll(Guid? id, bool trackChanges);
        IEnumerable<Models.Card> GetCards(Guid userId, bool trackChanges);
        Models.Card GetCard(Guid userId, Guid? id, bool trackChanges);
        void CreateCardForUser(Guid userId, Models.Card card);
        void DeleteCard(Models.Card card);

    }
}
