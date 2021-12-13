using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TimeReporter.Models
{
    public class Option
    {
        public Option()
        {
            SelectedDate = DateTime.Now; 
        }
        public Worker SelectedWorker { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime SelectedDate { get; set; }
        public List<string> Surnames { get; set; }
        public List<Entry> Entries { get; set; }

        public List<Entry> AllMonthEntries { get; set; }
    }
}