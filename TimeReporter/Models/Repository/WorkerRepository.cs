using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TimeReporter.Models.Repository
{
    public class WorkerRepository
    {
        private readonly TimeReporterContext _db;

        public WorkerRepository(TimeReporterContext db)
        {
            _db = db;
        }

        public Worker GetWorkerByLogin(string login)
        {
            return !_db.Workers.Any() ? null : _db.Workers.Single(worker => worker.Name == login);
        }

        public List<Worker> GetAllWorkers()
        {
            if (!_db.Workers.Any()) return null;
            return _db.Workers
                .Include(worker => worker.Entries)
                .Include(worker => worker.Reports)
                .ToList();
        }
    }
}