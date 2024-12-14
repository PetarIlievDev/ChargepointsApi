namespace Chargepoints.Services.Interfaces
{
    using System.Threading.Tasks;
    using Chargepoints.Services.Models;

    public interface ILocationService
    {
        Task<LocationRepsponseServiceModel> GetLocationByIdAsync(string locationId, CancellationToken ct);
        Task<bool> SaveLocationsAsync(LocationServiceModel saveLocation, CancellationToken ct);
        Task<bool> PatchLocationAsync(LocationServiceModel saveLocation, CancellationToken ct);
        Task<bool> UpsertChargePointsAsync(ChargePointServiceRequestModel saveLocation, CancellationToken ct);
    }
}
