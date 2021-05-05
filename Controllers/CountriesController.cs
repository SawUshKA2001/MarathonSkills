using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы countries
    /// </summary>
    public class CountriesController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о странах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о странах
        /// </returns>
        public List<countries> GetCountries()
        {
            return db.context.countries.ToList();
        }
    }
}
