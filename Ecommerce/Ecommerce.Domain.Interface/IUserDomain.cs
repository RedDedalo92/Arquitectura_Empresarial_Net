using Ecommerce.Domain.Entity;

namespace Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}
