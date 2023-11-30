namespace TrendBankServer.Repository.Transaction
{
    public interface ITransactionRepository
    {
        IEnumerable<Models.Transaction> GetTransactions(Guid cardId, bool trackChanges);
        Models.Transaction GetTransaction(Guid cardId, Guid id, bool trackChanges);
    }

}
