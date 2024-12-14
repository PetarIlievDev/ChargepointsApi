namespace Chargepoints.Repositories.Interfaces
{
    using System.Threading.Tasks;
    using Chargepoints.DataAccess.Models;

    public interface ILocationRepository
    {
        Task<Location> GetLocationByIdAsync(string locationId, CancellationToken ct);
        Task<int> SaveLocationsAsync(Location location, CancellationToken ct);
        Task<int> UpdateLocationAsync(Location location, CancellationToken ct);
    }
}
