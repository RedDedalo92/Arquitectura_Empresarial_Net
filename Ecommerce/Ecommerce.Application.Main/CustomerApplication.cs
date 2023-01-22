using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;

namespace Ecommerce.Application.Main
{
    public class CustomerApplication: ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper, IAppLogger<CustomerApplication> logger)
        {
            this._customerDomain = customerDomain;
            this._mapper = mapper;
            _logger = logger;
        }

        #region Metodos sincronos
        public Response<bool> Insert(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                response.Data = _customerDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Resgistro exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public Response<bool> Update(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                response.Data = _customerDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public Response<CustomerDTO> Get(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        #endregion

        #region Metodos asincronos
        public async Task<Response<bool>> InsertAsync(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                response.Data = await _customerDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Resgistro exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<CustomerDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        #endregion
    }
}
