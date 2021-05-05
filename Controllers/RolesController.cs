using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы roles
    /// </summary>
    public class RolesController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о ролях
        /// </summary>
        /// <returns>
        /// Лист с ролями
        /// </returns>
        public List<roles> GetRoles()
        {
            return db.context.roles.ToList();
        }
    }
}
