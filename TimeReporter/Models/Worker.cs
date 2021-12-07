using System.Text.Json.Serialization;

namespace TimeReporter.Models
{
    public class Worker
    {
        public Worker(string name)
        {
            Name = name;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        public const string SessionLogin = "SessionLogin";
    }
}