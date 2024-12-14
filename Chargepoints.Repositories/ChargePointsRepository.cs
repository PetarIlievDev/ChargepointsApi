namespace Chargepoints.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Chargepoints.DataAccess;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Helpers.Enums;
    using Chargepoints.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ChargePointsRepository(ApplicationDbContext context) : IChargePointsRepository
    {
        public async Task<List<ChargePoint>> GetChargePointsByLocationIdAync(string locationId, CancellationToken ct)
        {
            var result = await context.ChargePoints.Where(x => x.LocationId == locationId).AsNoTracking().ToListAsync(ct);
            return result;
        }

        public async Task<bool> UpsertChargePointsAsync(List<ChargePoint> forUpdate, List<ChargePoint> forInsert, List<string> forStatusChange, CancellationToken ct)
        {
            if(forUpdate != null && forUpdate.Count > 0)
            {
                context.ChargePoints.UpdateRange(forUpdate);
            }

            if (forInsert != null && forInsert.Count > 0)
            {
                context.ChargePoints.AddRange(forInsert);
            }

            foreach (var chargePointId in forStatusChange)
            {
                var chargePoint = await context.ChargePoints.FirstOrDefaultAsync(x => x.ChargePointId == chargePointId, ct);
                if (chargePoint != null)
                {
                    chargePoint.Status = StatusEnum.Removed;
                    context.ChargePoints.Update(chargePoint);
                }
            }

            return await context.SaveChangesAsync(ct) > 0;
        }
    }
}
