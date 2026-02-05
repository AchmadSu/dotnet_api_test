using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace api.Mapping
{
    public class GlobalMappingProfile<TDto, TModel> : Profile
    {
        public GlobalMappingProfile()
        {
            CreateMap<TDto, TModel>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}