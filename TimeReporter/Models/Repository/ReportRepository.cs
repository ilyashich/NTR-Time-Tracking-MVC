using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TimeReporter.Models.Repository
{
    public class ReportRepository
    {
        private readonly TimeReporterContext _db;

        public ReportRepository(TimeReporterContext db)
        {
            _db = db;
        }

        public Report GetReport(Worker worker, DateTime date)
        {
            if (!_db.Reports.Any()) return null;
            var reports = _db.Reports
                .Include(report => report.Entries)
                .Include(report => report.Worker)
                .Include(report => report.Accepted)
                .ThenInclude(accepted => accepted.Activity)
                .ThenInclude(activity => activity.Worker)
                .ToList();
            return reports.SingleOrDefault(r =>
                r.WorkerId == worker.WorkerId && r.Date.Month == date.Month && r.Date.Year == date.Year);

        }
        
        public Report GetReport(int workerId, string month, int year)
        {
            if (!_db.Reports.Any()) return null;
            var reports = _db.Reports
                .Include(report => report.Entries)
                .Include(report => report.Accepted)
                .Include(report => report.Worker)
                .ToList();
            return reports.SingleOrDefault(r =>
                r.WorkerId == workerId && r.Date.Month == int.Parse(month) && r.Date.Year == year);

        }

        public List<Entry> GetDayEntries(Worker worker, DateTime date)
        {
            if (!_db.Entries.Any()) return new List<Entry>();
            var entries = _db.Entries
                .Include(entry => entry.Activity)
                .Include(entry => entry.Subactivity)
                .Include(entry => entry.Worker)
                .Include(entry => entry.Report)
                .ToList();
            return entries.Where(e => e.WorkerId == worker.WorkerId && e.Date.Date == date.Date).ToList();

        }
        
        public Entry GetEntryById(int entryId)
        {
            if (!_db.Entries.Any()) return null;
            var entries = _db.Entries
                .Include(entry => entry.Activity)
                .Include(entry => entry.Subactivity)
                .Include(entry => entry.Worker)
                .Include(entry => entry.Report)
                .ToList();
            return entries.SingleOrDefault(e => e.EntryId == entryId);

        }

        public AcceptedTime GetAccepted(Report report, int activityId)
        {
            return (from accepted in _db.Accepted
                where accepted.ReportId == report.ReportId
                      && accepted.Activity.ActivityId == activityId
                select accepted).SingleOrDefault();
        }
        
        public List<AcceptedTime> GetAccepted(int activityId)
        {
            if (!_db.Accepted.Any()) return null;
            var accepted = _db.Accepted
                .Include(accept => accept.Worker)
                .Include(accept => accept.Report)
                .ThenInclude(report => report.Entries)
                .ToList();
            return accepted.Where(accept => accept.ActivityId == activityId).ToList();
        }


    }
}