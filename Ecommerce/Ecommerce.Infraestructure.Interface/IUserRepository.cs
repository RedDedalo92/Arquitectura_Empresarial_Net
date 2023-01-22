using Ecommerce.Domain.Entity;

namespace Ecommerce.Infraestructure.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
