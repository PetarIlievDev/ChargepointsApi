﻿namespace Chargepoints.Services.Models
{
    using System;
    using System.Collections.Generic;
    using Chargepoints.DataAccess.Models;
    using Chargepoints.Helpers.Enums;

    public class LocationServiceModel
    {
        public string LocationId { get; set; }
        public TypeEnum? Type { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
