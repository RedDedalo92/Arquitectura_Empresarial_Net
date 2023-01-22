using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;
using System;

namespace Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserApplication(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parametros no pueden ser vacios";
                return response;
            }
            try
            {
                var user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "autenticacion exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}
