namespace Chargepoints.Services.MappingProfiles
{
    using AutoMapper;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Services.Models;

    public class ChargePointsServiceMappingProfile : Profile
    {
        public ChargePointsServiceMappingProfile()
        {
            CreateMap<ChargePointServiceModel, ChargePoint>();
        }
    }
}
