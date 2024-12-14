namespace ChargepointsAPI.Models
{
    public class GetLocationResponseModel : LocationRequestModel
    {
       public List<ChargePointRequest> ChargePoints { get; set; }
    }
}
