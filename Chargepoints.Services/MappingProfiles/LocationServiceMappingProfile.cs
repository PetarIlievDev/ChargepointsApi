namespace Chargepoints.Services.MappingProfiles
{
    using AutoMapper;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Services.Models;

    public class LocationServiceMappingProfile : Profile
    {
        public LocationServiceMappingProfile()
        {
            CreateMap<LocationServiceModel, Location>();
            CreateMap<Location, LocationRepsponseServiceModel>();
            CreateMap<ChargePoint, ChargePointServiceModel>();
        }
    }
}
