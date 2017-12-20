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
            CreateMap<CategoryDto, Category>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

        }
    }
}
