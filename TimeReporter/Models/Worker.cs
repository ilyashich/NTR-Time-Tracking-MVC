using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeReporter.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set;  }
        
        [Required]
        public string Name { get; set; }
        
        public virtual List<Activity> Activities { get; set; }
        public virtual List<Entry> Entries { get; set; }
        public virtual List<Report> Reports { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

    }
}