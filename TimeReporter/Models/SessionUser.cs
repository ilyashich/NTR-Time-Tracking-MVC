using Microsoft.AspNetCore.Http;
using TimeReporter.Models.Repository;

namespace TimeReporter.Models
{
    public class SessionUser
    {
        public const string SessionLogin = "SessionLogin";

        public static Worker GetSessionUser(IHttpContextAccessor httpContextAccessor, TimeReporterContext context)
        {
            string login = httpContextAccessor.HttpContext.Session.GetString(SessionLogin);
            WorkerRepository workerRepository = new WorkerRepository(context);
            return workerRepository.GetWorkerByLogin(login);
        }
        
    }
}