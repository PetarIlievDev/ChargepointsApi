namespace Chargepoints.Services
{
    using AutoMapper;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Helpers.Enums;
    using Chargepoints.Repositories.Interfaces;
    using Chargepoints.Services.Interfaces;
    using Chargepoints.Services.Models;

    public class LocationService(IMapper mapper, ILocationRepository locationRepository, IChargePointsRepository chargePointsRepository) : ILocationService
    {
        public async Task<LocationRepsponseServiceModel> GetLocationByIdAsync(string locationId, CancellationToken ct)
        {
            var location = await locationRepository.GetLocationByIdAsync(locationId, ct);
            var result = mapper.Map<LocationRepsponseServiceModel>(location);

            return result;
        }

        public async Task<bool> SaveLocationsAsync(LocationServiceModel saveLocation, CancellationToken ct)
        {
            var location = mapper.Map<Location>(saveLocation);
            var result = await locationRepository.SaveLocationsAsync(location, ct);

            return result > 0;
        }

        public async Task<bool> UpdateLocationAsync(LocationServiceModel saveLocation, CancellationToken ct)
        {
            var location = mapper.Map<Location>(saveLocation);
            var result = await locationRepository.UpdateLocationAsync(location, ct);

            return result > 0;
        }

        public async Task<bool> PatchLocationAsync(LocationServiceModel saveLocation, CancellationToken ct)
        {
            var location = mapper.Map<Location>(saveLocation);
            var model = await GetLocationByIdAsync(location.LocationId, ct);

            if (model == null)
            {
                return false;
            }

            ////Using Reflection to update only the properties that are not null
            //location.GetType().GetProperties().ToList().ForEach(prop =>
            //{
            //    if (prop.GetValue(location) == null)
            //    {
            //        var valueFromDb = model?.GetType()?.GetProperty(prop.Name)?.GetValue(model);
            //        if (valueFromDb != null)
            //        {
            //            prop.SetValue(location, valueFromDb);
            //        }
            //    }
            //});

            location.Name ??= model.Name;
            location.Address ??= model.Address;
            location.City ??= model.City;
            location.PostalCode ??= model.PostalCode;
            location.Country ??= model.Country;
            if (saveLocation.Type == null) location.Type = (TypeEnum)model?.Type;
            if (location.LastUpdated == DateTime.MinValue) location.LastUpdated = model.LastUpdated;

            var result = await locationRepository.UpdateLocationAsync(location, ct);

            return result > 0;
        }

        public async Task<bool> UpsertChargePointsAsync(ChargePointServiceRequestModel chargePointsModel, CancellationToken ct)
        {
            List<ChargePoint> forUpdate = [];
            List<ChargePoint> forInsert = [];
            var existingItems = await chargePointsRepository.GetChargePointsByLocationIdAync(chargePointsModel.LocationId, ct);
            var chargeIds = chargePointsModel.ChargePoints.Select(x => x.ChargePointId).ToList();
            List<string> forStatusChange = existingItems.Select(x => x.ChargePointId).Except(chargeIds).ToList();
            List<string> existingItemsIds = existingItems.Select(x => x.ChargePointId).ToList();


            foreach (var item in chargePointsModel.ChargePoints) 
            {
                if (existingItemsIds.Contains(item.ChargePointId))
                {
                    ChargePoint existingChargePoint = new()
                    {
                        ChargePointId = item.ChargePointId,
                        LocationId = chargePointsModel.LocationId,
                        FloorLevel = item.FloorLevel,
                        Status = item.Status,
                        LastUpdated = item.LastUpdated
                    };

                    forUpdate.Add(existingChargePoint);
                    continue;
                }

                if (!existingItemsIds.Contains(item.ChargePointId))
                {
                    ChargePoint existingChargePoint = new()
                    {
                        ChargePointId = item.ChargePointId,
                        LocationId = chargePointsModel.LocationId,
                        FloorLevel = item.FloorLevel,
                        Status = item.Status,
                        LastUpdated = item.LastUpdated
                    };

                    forInsert.Add(existingChargePoint);
                }
            }

            var result = await chargePointsRepository.UpsertChargePointsAsync(forUpdate, forInsert, forStatusChange, ct);
            
            return result;
        }
    }
}
