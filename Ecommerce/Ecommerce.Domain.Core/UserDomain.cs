using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Interface;

namespace Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }
    }
}
