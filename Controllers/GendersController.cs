using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы genders
    /// </summary>
    public class GendersController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о полах
        /// </summary>
        /// <returns>
        /// Лист с данными о полах
        /// </returns>
        public List<genders> GetGenders()
        {
            return db.context.genders.ToList();
        }
    }
}
