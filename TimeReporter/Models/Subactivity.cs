using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TimeReporter.Models
{
    public class Subactivity
    {
        [Key]
        public int SubactivityId { get; set;  }
        
        [Required]
        public string Code { get; set; }
        
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set;  }
        public virtual List<Entry> Entries { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
    }
}