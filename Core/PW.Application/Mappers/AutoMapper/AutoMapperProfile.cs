using AutoMapper;
using PW.Application.Models.ViewModels.Membership;
using PW.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Application.Mappers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserListViewModel>().ReverseMap();
            CreateMap<User, UserCreateViewModel>().ReverseMap();
            CreateMap<User, UserUpdateViewModel>().ReverseMap();
        }
    }
}
