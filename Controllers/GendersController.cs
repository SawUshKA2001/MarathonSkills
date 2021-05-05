using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class GendersController
    {
        readonly Core db = new Core();
        public List<genders> GetGenders()
        {
            return db.context.genders.ToList();
        }
    }
}
