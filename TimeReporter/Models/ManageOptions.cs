﻿using System.Collections.Generic;
using System;

namespace TimeReporter.Models
{
    public class ManageOption
    {
        public ManageOption()
        {
            SelectedMonth = DateTime.Now.Month.ToString();
            SelectedYear = DateTime.Now.Year;
            IsFrozen = new List<bool>();
            SubmittedTime = new List<int>();
            AcceptedTime = new List<int>();
        }

        public int SelectedWorkerId { get; set; }
        
        public int SelectedProjectId { get; set; }
        
        public string SelectedMonth { get; set; }

        public int SelectedYear { get; set; }
        
        public List<bool> IsFrozen { get; set; }
        
        public int? SelectedProjectBudget { get; set; }

        public bool IsSelectedProjectActive { get; set; }
        
        public List<int> SubmittedTime { get; set; }

        public List<int> AcceptedTime { get; set; }
        
        public List<string> Surnames { get; set; }

        public List<Activity> Projects { get; set; }

        public List<Worker> ProjectWorkers { get; set; }
    }
}