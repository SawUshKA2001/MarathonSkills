using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы charities
    /// </summary>
    public class CharitiesController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о благотворительных организациях
        /// </summary>
        /// <returns>
        /// Возвращает лист данных о благотворительных организациях
        /// </returns>
        public List<charities> GetCharities()
        {
            return db.context.charities.ToList();
        }
    }
}
