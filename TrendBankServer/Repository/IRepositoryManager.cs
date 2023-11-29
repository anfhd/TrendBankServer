namespace TrendBankServer.Repository
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        ICardRepository Card { get; }
        ITransactionRepository Transaction { get; }
        void Save();
    }

}
