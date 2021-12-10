using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeReporter.Models
{
    public class Report
    {
        [Key] 
        public int ReportId { get; set;  }

        [Required]
        public bool Frozen { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        
        [ForeignKey("Worker")]
        public int WorkerId { get; set; }


        public virtual Worker Worker { get; set;  }
        public virtual List<Entry> Entries { get; set; }
        public virtual List<AcceptedTime> Accepted { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

    }
}