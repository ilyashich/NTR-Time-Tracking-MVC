using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimeReporter.Models
{
    public class Activity
    {
        [Key] 
        public int ActivityId { get; set; }

        [Required]
        public string Code { get; set; }

        [ForeignKey("Worker")]
        public int WorkerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual List<Subactivity> Subactivities { get; set; }
        public virtual List<Entry> Entries { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
        
    }
}