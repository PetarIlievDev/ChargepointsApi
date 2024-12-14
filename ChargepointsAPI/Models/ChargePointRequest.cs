namespace ChargepointsAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Chargepoints.Helpers.Enums;

    public class ChargePointRequest
    {
        [Required]
        public string ChargePointId { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnum Status { get; set; }

        public string FloorLevel { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
