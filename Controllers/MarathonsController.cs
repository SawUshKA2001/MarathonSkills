using MarathonSkills.Models;
using System;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы marathons
    /// </summary>
    public class MarathonsController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о марафоне этого года
        /// </summary>
        /// <returns>
        /// Объект с данными о марафоне
        /// </returns>
        public marathons GetCurrentMarathonInfo()
        {
            return db.context.marathons.Where(x => x.marathon_year == DateTime.Now.Year).FirstOrDefault();
        }
    }
}
