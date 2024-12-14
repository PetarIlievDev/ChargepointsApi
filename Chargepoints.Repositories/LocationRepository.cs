namespace Chargepoints.Repositories
{
    using Chargepoints.DataAccess;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class LocationRepository(ApplicationDbContext context) : ILocationRepository
    {
        public async Task<Location> GetLocationByIdAsync(string locationId, CancellationToken ct)
        {
            var result = await context.Locations
                .Include(x => x.ChargePoints)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => EF.Functions.Like(x.LocationId, locationId), ct);

            return result;
        }

        public async Task<int> SaveLocationsAsync(Location location, CancellationToken ct) 
        { 
            context.Locations.Add(location);
            return await context.SaveChangesAsync(ct);
        }

        public async Task<int> UpdateLocationAsync(Location location, CancellationToken ct)
        {
            context.Locations.Update(location);
            return await context.SaveChangesAsync(ct);
        }
    }
}
