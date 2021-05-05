using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class RolesController
    {
        readonly Core db = new Core();
        public List<roles> GetRoles()
        {
            return db.context.roles.ToList();
        }
    }
}
