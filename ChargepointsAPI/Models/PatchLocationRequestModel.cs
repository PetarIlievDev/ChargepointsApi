namespace ChargepointsAPI.Models
{
    using System.Text.Json.Serialization;
    using Chargepoints.Helpers.Enums;

    public class PatchLocationRequestModel
    {
        [JsonIgnore]
        public string? LocationId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeEnum? Type { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
