namespace Chargepoints.Services.Models
{
    using System;
    using Chargepoints.Helpers.Enums;

    public class ChargePointServiceModel
    {
        public string ChargePointId { get; set; }
        public StatusEnum Status { get; set; }

        public string FloorLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
