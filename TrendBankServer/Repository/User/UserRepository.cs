using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository.User
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

        public Models.User GetUser(Guid userId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(userId), trackChanges)
            .SingleOrDefault();

        public void CreateUser(Models.User user) =>
            Create(user);
    }

}
