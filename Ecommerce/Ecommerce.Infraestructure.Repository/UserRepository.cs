using Dapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Infraestructure.Interface;
using Ecommerce.Transversal.Common;
using System.Data;

namespace Ecommerce.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly IConnectionFactory _conectionFactory;

        public UserRepository(IConnectionFactory conectionFactory)
        {
            _conectionFactory = conectionFactory;
        }

        public User Authenticate(string userName, string password)
        {
            using (var connection = _conectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
