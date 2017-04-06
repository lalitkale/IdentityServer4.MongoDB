﻿using System.Linq;
using AutoMapper;
using IdentityServer4.MongoDB.Entities;

namespace IdentityServer4.MongoDB.Mappers
{
    /// <summary>
    /// AutoMapper configuration for identity resource
    /// Between model and entity
    /// </summary>
    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            // entity to model
            CreateMap<IdentityResource, global::IdentityServer4.Models.IdentityResource>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)));

            // model to entity
            CreateMap<global::IdentityServer4.Models.IdentityResource, IdentityResource>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new IdentityClaim {Type = x})));
        }
    }
}