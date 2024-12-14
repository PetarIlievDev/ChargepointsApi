namespace Chargepoints.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Chargepoints.DataAccess.Models;

    public interface IChargePointsRepository
    {
        Task<List<ChargePoint>> GetChargePointsByLocationIdAync(string locationId, CancellationToken ct);

        Task<bool> UpsertChargePointsAsync(List<ChargePoint> forUpdate, List<ChargePoint> forInsert, List<string> forStatusChange, CancellationToken ct);
    }
}
