using TrendBankServer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository.User
{
    public interface IUserRepository
    {
        IEnumerable<Models.User> GetAllUsers(bool trackChanges);
        Models.User GetUser(Guid userId, bool trackChanges);
        void CreateUser(Models.User user);
    }
}
