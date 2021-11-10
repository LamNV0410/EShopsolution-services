using Authentication.API.Queries;
using System.Threading.Tasks;

namespace Authentication.API.Application.Queries
{
    public interface IUserQueries
    {
        Task<UserInfo> GetUsersAsync(string userName);
    }
}
