using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы events
    /// </summary>
    public class EventsController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение информации о забегах
        /// </summary>
        /// <returns></returns>
        public List<events> GetEvents()
        {
            return db.context.events.ToList();
        }
    }
}
