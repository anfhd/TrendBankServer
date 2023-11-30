using TrendBankServer.Repository.Card;
using TrendBankServer.Repository.Transaction;
using TrendBankServer.Repository.User;

namespace TrendBankServer.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _userRepository;
        private ICardRepository _cardRepository;
        private ITransactionRepository _transactionRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }
        public ICardRepository Card
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new CardRepository(_repositoryContext);
                return _cardRepository;
            }
        }
        public ITransactionRepository Transaction
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new TransactionRepository(_repositoryContext);
                return _transactionRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }

}
