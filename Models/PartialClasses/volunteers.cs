using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills.Models
{
    /// <summary>
    /// Объект таблицы volunteers
    /// </summary>
    public partial class volunteers
    {
        /// <summary>
        /// Вычисляемое значение полного имени волонтёра
        /// </summary>
        public string VolunteerFullName { get 
            {
                return volunteer_lastname + " " + volunteer_firstname + " " + volunteer_othername;
            } }
    }
}
