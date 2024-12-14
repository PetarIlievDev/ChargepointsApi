namespace Chargepoints.Services.Models
{
    using System.Collections.Generic;

    public class LocationRepsponseServiceModel : LocationServiceModel
    {
        public List<ChargePointServiceModel> ChargePoints { get; set; }
    }
}
