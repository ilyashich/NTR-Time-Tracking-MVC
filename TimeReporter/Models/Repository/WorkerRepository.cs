using System.Linq;

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
            return _db.Workers.Single(worker => worker.Name == login);
        }
    }
}