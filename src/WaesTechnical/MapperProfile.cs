using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical.Domain.Models;
using WaesTechnical.Infrastructure.Entities;

namespace WaesTechnical
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DataDto, DataEntity>();
            CreateMap<DataEntity, DataDto>();
            CreateMap<DataModel, DataDto>();
            CreateMap<DataDto, DataModel>();
        }

    }
}
