namespace ChargepointsAPI.Controllers
{
    using AutoMapper;
    using Chargepoints.Services.Interfaces;
    using Chargepoints.Services.Models;
    using ChargepointsAPI.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(IMapper mapper, ILocationService locationService) : ControllerBase
    {
        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocation(string locationId, CancellationToken ct)
        {
            var result = await locationService.GetLocationByIdAsync(locationId, ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostLocation(LocationRequestModel model, CancellationToken ct)
        {
            var saveLocation = mapper.Map<LocationServiceModel>(model);
            var result = await locationService.SaveLocationsAsync(saveLocation, ct);
            return Ok(result);
        }

        [HttpPatch("{locationId}")]
        public async Task<IActionResult> PatchLocation(string locationId, PatchLocationRequestModel model, CancellationToken ct)
        {
            model.LocationId = locationId;
            var saveLocation = mapper.Map<LocationServiceModel>(model);
            var result = await locationService.PatchLocationAsync(saveLocation, ct);
            return Ok(result);
        }

        [HttpPut("{locationId}")]
        public async Task<IActionResult> PutLocation(string locationId, ChargePointRequestModel model, CancellationToken ct)
        {
            model.LocationId = locationId;
            var chargePoint = mapper.Map<ChargePointServiceRequestModel>(model);
            var result = await locationService.UpsertChargePointsAsync(chargePoint, ct);
            return Ok(result);
        }
    }

}
