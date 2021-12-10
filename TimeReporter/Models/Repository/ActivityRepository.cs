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

        public void AddNewActivity(Activity activity)
        {
            Activity sameActivities = _db.Activities.SingleOrDefault(currentActivity => currentActivity.Code == activity.Code);

            if (sameActivities == null)
            {
                _db.Activities.Add(activity);
                _db.SaveChanges();
            }
        }
    }
}