using System.Text.Json.Serialization;

namespace DotNETTask.Domains.Models
{
    public record BaseEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
