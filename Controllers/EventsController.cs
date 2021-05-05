using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class EventsController
    {
        readonly Core db = new Core();
        public List<events> GetEvents()
        {
            return db.context.events.ToList();
        }
    }
}
