namespace ChargepointsAPI.Models
{
    using System.Text.Json.Serialization;

    public class ChargePointRequestModel
    {
        [JsonIgnore]
        public string? LocationId { get; set; }

        public List<ChargePointRequest> ChargePoints { get; set; }
}
}
