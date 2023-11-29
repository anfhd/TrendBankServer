using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Models.User> GetAllUsers(bool trackChanges);
    }
}
