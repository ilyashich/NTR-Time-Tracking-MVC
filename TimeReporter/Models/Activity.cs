using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace TimeReporter.Models
{
    public class Activity
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("manager")]
        public string Manager { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("budget")]
        public int Budget { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("subactivities")]
        public List<Subactivity> Subactivities { get; set; }

        public List<string> GetAllSubactivities()
        {
            return Subactivities.Select(subactivity => subactivity.Code).ToList();
        }

        public List<Worker> GetAllWorkersForActivity(string month, int year)
        {
            List<Worker> workers = new List<Worker>();
            List<Worker> allWorkers = JsonSerde.GetData().Workers;
            foreach (var worker in allWorkers)
            {
                string reportFile = "../TimeReporter/data/" + worker.Name + "-" + year + "-" + month + ".json";
                if (System.IO.File.Exists(reportFile))
                {
                    string jsonString = System.IO.File.ReadAllText(reportFile);
                    Report report = JsonSerializer.Deserialize<Report>(jsonString);

                    if (report != null)
                    {
                        foreach (var entry in report.Entries)
                        {
                            if (entry.Code == Code && !workers.Contains(worker))
                            {
                                workers.Add(worker);
                            }
                        }
                    }
                }
            }

            return workers;
        }
    }
}