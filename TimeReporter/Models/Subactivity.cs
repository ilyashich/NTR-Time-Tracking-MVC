using System.Text.Json.Serialization;

namespace TimeReporter.Models
{
    public class Subactivity
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}