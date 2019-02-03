using System.Threading.Tasks;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public Task<User> Login(string username, string password)
        {
            //TODO: Add APS.NET Identity
            User user = new User() { Id = 1, Username = username, Password = password };
            return Task<User>.Factory.StartNew(() => user); 
        }
    }
}