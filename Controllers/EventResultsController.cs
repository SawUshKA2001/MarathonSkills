using MarathonSkills.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{

    /// <summary>
    /// Логика взаимодействия с БД для таблицы event_results
    /// </summary>
    public class EventResultsController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение результатов забегов
        /// </summary>
        /// <returns>
        /// Лист с данными о результатами забегов
        /// </returns>
        public List<event_results> GetResults()
        {
            return db.context.event_results.ToList();
        }

        /// <summary>
        /// Получение результатов забегов для бегуна
        /// </summary>
        /// <param name="runnerId">
        /// ID бегуна
        /// </param>
        /// <returns>
        /// Лист с данными о результатами забегов
        /// </returns>
        public List<event_results> GetCurrentRunnerResults(int runnerId)
        {
            return GetResults().Where(x => x.runner_id == runnerId).ToList();
        }

        /// <summary>
        /// Получение результатов забегов для забега
        /// </summary>
        /// <param name="eventId">
        /// ID забега
        /// </param>
        /// <returns>
        /// Лист с данными о результатами забегов
        /// </returns>
        public List<event_results> GetCurrentEventResults(int eventId)
        {
            return GetResults().Where(x => x.event_id == eventId).ToList();
        }
    }
}
