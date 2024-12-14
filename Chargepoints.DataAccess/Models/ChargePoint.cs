namespace Chargepoints.DataAccess.Models
{
    using System;
    using Chargepoints.Helpers.Enums;

    public class ChargePoint
    {
        public string ChargePointId { get; set; }
        public StatusEnum Status { get; set; }
        public string FloorLevel { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
    }
}
