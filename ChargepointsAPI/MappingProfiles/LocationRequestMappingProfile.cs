namespace ChargepointsAPI.MappingProfiles
{
    using AutoMapper;
    using Chargepoints.Services.Models;
    using ChargepointsAPI.Models;

    public class LocationRequestMappingProfile : Profile
    {
        public LocationRequestMappingProfile()
        {
            CreateMap<LocationRequestModel, LocationServiceModel>();
            CreateMap<LocationRequestModel, LocationServiceModel>();
            CreateMap<PatchLocationRequestModel, LocationServiceModel>();
        }
    }
}
