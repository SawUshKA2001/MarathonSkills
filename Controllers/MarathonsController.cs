using MarathonSkills.Models;
using System;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class MarathonsController
    {
        readonly Core db = new Core();
        public marathons GetCurrentMarathonInfo()
        {
            return db.context.marathons.Where(x => x.marathon_year == DateTime.Now.Year).FirstOrDefault();
        }
    }
}
