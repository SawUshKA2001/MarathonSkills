using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class CountriesController
    {
        readonly Core db = new Core();
        public List<countries> GetCountries()
        {
            return db.context.countries.ToList();
        }
    }
}
