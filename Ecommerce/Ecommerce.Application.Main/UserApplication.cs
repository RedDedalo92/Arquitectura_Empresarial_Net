using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Application.Validator;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;
using System;

namespace Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDTOValidator _usersDTOValidator;

        public UserApplication(IUserDomain userDomain, IMapper mapper, UserDTOValidator usersDTOValidator)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _usersDTOValidator = usersDTOValidator;
        }

        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _usersDTOValidator.Validate(new UserDTO { UserName= username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Parametros no pueden ser vacios";
                response.Errors = validation.Errors;
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
