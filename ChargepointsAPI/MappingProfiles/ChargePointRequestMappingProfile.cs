namespace ChargepointsAPI.MappingProfiles
{
    using AutoMapper;
    using Chargepoints.Services.Models;
    using ChargepointsAPI.Models;

    public class ChargePointRequestMappingProfile : Profile
    {
        public ChargePointRequestMappingProfile()
        {
            CreateMap<ChargePointRequestModel, ChargePointServiceRequestModel>();
            CreateMap<ChargePointRequest, ChargePointServiceModel>();
        }
    }
}