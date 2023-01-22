using Ecommerce.Application.DTO;
using Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Metodos sincronos
        Response<bool> Insert(CustomerDTO customerDTO);
        Response<bool> Update(CustomerDTO customerDTO);
        Response<bool> Delete(string customerId);
        Response<CustomerDTO> Get(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        #endregion

        #region Metodos asincronos
        Task<Response<bool>> InsertAsync(CustomerDTO customerDTO);
        Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        #endregion
    }
}
