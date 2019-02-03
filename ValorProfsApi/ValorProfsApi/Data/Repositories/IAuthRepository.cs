using System.Threading.Tasks;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<User> LoginAsync(string username, string password);
    }
}