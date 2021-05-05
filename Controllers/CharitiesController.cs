using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class CharitiesController
    {
        readonly Core db = new Core();
        public List<charities> GetCharities()
        {
            return db.context.charities.ToList();
        }
    }
}
