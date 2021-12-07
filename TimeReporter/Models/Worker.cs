using System.Text.Json.Serialization;

namespace TimeReporter.Models
{
    public class Worker
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        public const string SessionLogin = "SessionLogin";
    }
}