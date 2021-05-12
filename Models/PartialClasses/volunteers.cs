using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills.Models
{
    public partial class volunteers
    {
        public string VolunteerFullName { get 
            {
                return volunteer_lastname + " " + volunteer_firstname + " " + volunteer_othername;
            } }
    }
}
