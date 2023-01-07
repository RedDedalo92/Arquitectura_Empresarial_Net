using Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.Interface
{
    public interface ICustomerRepository
    {
        #region Metodos sincronos
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string customerId);
        Customer Get(string customerId);
        IEnumerable<Customer> GetAll();
        #endregion

        #region Metodos asincronos
        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        #endregion
    }
}
