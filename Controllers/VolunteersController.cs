using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class VolunteersController
    {
        Core db = new Core();
        public List<volunteers> GetVolunteers()
        {
            return db.context.volunteers.ToList();
        }

        public bool AddNewVolunteer(string firstName, string lastName, string otherName, DateTime birthDate, int countryId, string genderCode)
        {
            try
            {
                volunteers newVolunteer = new volunteers
                {
                    volunteer_firstname = firstName,
                    volunteer_lastname = lastName,
                    volunteer_othername = otherName,
                    volunteer_birthdate = birthDate,
                    country_id = countryId,
                    gender_code = genderCode
                };
                db.context.volunteers.Add(newVolunteer);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка при добавлении");
            }
        }

        public bool UpdateVolunteer(string firstName, string lastName, string otherName, DateTime birthDate, int countryId, string genderCode, volunteers volunteer)
        {
            try
            {
                volunteers editedVolunteer = db.context.volunteers.Where(x => x.volunteer_id == volunteer.volunteer_id).FirstOrDefault();
                editedVolunteer.volunteer_firstname = firstName;
                editedVolunteer.volunteer_lastname = lastName;
                editedVolunteer.volunteer_othername = otherName;
                editedVolunteer.volunteer_birthdate = birthDate;
                editedVolunteer.country_id = countryId;
                editedVolunteer.gender_code = genderCode;

                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка при обновлении");
            }
        }
    }
}
