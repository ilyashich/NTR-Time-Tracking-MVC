using System.Linq;

namespace TimeReporter.Models.Repository
{
    public class ActivityRepository
    {
        private readonly TimeReporterContext _db;

        public ActivityRepository(TimeReporterContext db)
        {
            _db = db;
        }

        public bool AddNewActivity(Activity activity)
        {
            Activity sameActivities = _db.Activities.SingleOrDefault(currentActivity => currentActivity.Code == activity.Code);

            if (sameActivities != null) return false;
            _db.Activities.Add(activity);
            _db.SaveChanges();
            return true;

        }
    }
}