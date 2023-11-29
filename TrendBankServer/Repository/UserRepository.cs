using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public class UserRepository : RepositoryBase<Models.User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public IEnumerable<Models.User> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToList();
    }

}
