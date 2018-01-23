using AutoMapper;
using Dot.Library.Database;
using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>()
                   .ForMember(dest => dest.Name,
                           opts => opts.MapFrom(
                               src => string.Format("{0}", src.ParentCategory)
                               ));

            CreateMap<MessageDto, Message>()
                .ForMember(dest => dest.User,
                           opts => opts.MapFrom(
                               src => string.Format("{0} {1}", src.FirstName,
                                    src.LastName)
                               ));
            CreateMap<Message, MessageDto>();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Address,
                           opts => opts.MapFrom(
                               src => string.Format("{0}", src.Street)
                               ));
            CreateMap<User, UserDto>();


        }
    }
}