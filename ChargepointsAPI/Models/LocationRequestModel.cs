namespace ChargepointsAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Chargepoints.Helpers.Enums;

    public class LocationRequestModel
    {
        [Required]
        public string LocationId { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeEnum Type { get; set; }

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
