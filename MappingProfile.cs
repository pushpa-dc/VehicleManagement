using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(v => v.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(v => v.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(v => v.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.MapFrom(v => v.Features.Select(id => new VehicleFeature { FeatureId = id })));
        }
    }
}
