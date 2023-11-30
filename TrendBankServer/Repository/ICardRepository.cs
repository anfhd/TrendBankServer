namespace TrendBankServer.Repository
{
    public interface ICardRepository
    {
        IEnumerable<Models.Card> GetCards(Guid userId, bool trackChanges);
        Models.Card GetCard(Guid userId, Guid id, bool trackChanges);
    }
}
