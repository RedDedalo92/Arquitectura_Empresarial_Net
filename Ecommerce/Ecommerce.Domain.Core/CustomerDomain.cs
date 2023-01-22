using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomain(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #region Metodos Sincronos

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public bool Delete(string idCustomer)
        {
            return (_customerRepository.Delete(idCustomer));
        }

        public Customer Get(string idCustomer)
        {
            return _customerRepository.Get(idCustomer);
        }

        public IEnumerable<Customer> GetAll() 
        { 
            return _customerRepository.GetAll(); 
        }
        #endregion

        #region Metodos asincronos
        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(string idCustomer)
        {
            return await _customerRepository.DeleteAsync(idCustomer);
        }

        public async Task<Customer> GetAsync(string idCustomer)
        {
            return await _customerRepository.GetAsync(idCustomer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
        #endregion
    }
}
