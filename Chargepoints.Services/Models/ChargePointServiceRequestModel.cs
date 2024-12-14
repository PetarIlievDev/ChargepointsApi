namespace Chargepoints.Services.Models
{
    using System.Collections.Generic;

    public class ChargePointServiceRequestModel
    {
        public string LocationId { get; set; }

        public List<ChargePointServiceModel> ChargePoints { get; set; }
    }
}
