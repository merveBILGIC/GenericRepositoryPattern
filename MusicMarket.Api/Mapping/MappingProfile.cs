using AutoMapper;
using MusicMarket.Api.DTO;
using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Books, BooksDTO>();
            CreateMap<Writers, WritersDTO>();

            // Resource to Domain
            CreateMap<BooksDTO, Books>();
            CreateMap<WritersDTO, Writers>();

            CreateMap<SaveBooksDTo, Books>();
            CreateMap<SaveWritersDTO, Writers>();
        }
    }
}
