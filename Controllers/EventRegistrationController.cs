using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы event_registration
    /// </summary>
    public class EventRegistrationController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Добавление новой регистрации на забег
        /// </summary>
        /// <param name="eventId">
        /// ID забега
        /// </param>
        /// <param name="runnerId">
        /// ID бегуна
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если добавление произошло успешно
        /// false - если данная регистрация уже была добавлена
        /// Exception("Ошибка при регистрации на марафон.") - если при добавлении произошла ошибка
        /// </returns>
        public bool AddNewRegistration(int eventId, int runnerId)
        {
            event_registration checkRegistration = GetRegistrations().Where(x => x.event_id == eventId && x.runner_id == runnerId).FirstOrDefault();
            if (checkRegistration == null)
            {
                try
                {
                    event_registration registration = new event_registration
                    {
                        event_id = eventId,
                        runner_id = runnerId,
                        registration_datetime = DateTime.Now
                    };
                    db.context.event_registration.Add(registration);
                    db.context.SaveChanges();

                    return true;
                }
                catch
                {

                    throw new Exception("Ошибка при регистрации на марафон.");
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Получение данных о регистрациях
        /// </summary>
        /// <returns>
        /// Лист с данными о регистрациях
        /// </returns>
        public List<event_registration> GetRegistrations()
        {
            return db.context.event_registration.ToList();
        }
    }
}
