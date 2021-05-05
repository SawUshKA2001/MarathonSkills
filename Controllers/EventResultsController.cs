using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{

    public class EventResultsController
    {
        readonly Core db = new Core();
        public List<event_results> GetResults()
        {
            return db.context.event_results.ToList();
        }

        public List<event_results> GetCurrentRunnerResults(int runnerId)
        {
            return GetResults().Where(x => x.runner_id == runnerId).ToList();
        }

        public List<event_results> GetCurrentEventResults(int eventId)
        {
            return GetResults().Where(x => x.event_id == eventId).ToList();
        }
    }
}
