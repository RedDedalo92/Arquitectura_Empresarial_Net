using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Domain.Entity;
using System;

namespace Ecommerce.Transversal.Mapper
{
    //Clase que realiza mapeo automatico entre entidades y DTOs con AutoMapper 
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //Realiza mapeo de ida y vuelta, los atributos deben ser iguales, de otra forma se deben hacer
            //los mapeos miembro por miembro
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
