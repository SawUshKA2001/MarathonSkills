using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы volunteers
    /// </summary>
    public class VolunteersController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о волонтёрах
        /// </summary>
        /// <returns>
        /// Лист данных о волонтёрах
        /// </returns>
        public List<volunteers> GetVolunteers()
        {
            return db.context.volunteers.ToList();
        }

        /// <summary>
        /// Добавление нового волонтёра
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="otherName">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="countryId">ID страны</param>
        /// <param name="genderCode">Код гендера</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Ошибка при добавлении") - если произошла ошибка добавления
        /// </returns>
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

        /// <summary>
        /// Изменение данных волонтёра
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="otherName">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="countryId">ID страны</param>
        /// <param name="genderCode">Код гендера</param>
        /// <param name="volunteer">Старые данные волонтёра</param>
        /// <returns>
        /// true - если данные успешно обновлены
        /// Exception("Ошибка при обновлении") - если при обновлении произошла ошибка
        /// </returns>
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
