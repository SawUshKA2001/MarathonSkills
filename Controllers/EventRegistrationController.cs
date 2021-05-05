using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class EventRegistrationController
    {
        readonly Core db = new Core();
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

        public List<event_registration> GetRegistrations()
        {
            return db.context.event_registration.ToList();
        }
    }
}
