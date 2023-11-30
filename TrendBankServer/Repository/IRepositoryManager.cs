using TrendBankServer.Repository.Card;
using TrendBankServer.Repository.Transaction;
using TrendBankServer.Repository.User;

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
