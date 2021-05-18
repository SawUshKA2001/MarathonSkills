using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы runners
    /// </summary>
    public class RunnersController
    {
        readonly Core db = new Core();
        readonly UsersController userObj = new UsersController();

        /// <summary>
        /// Добавление нового бегуна
        /// </summary>
        /// <param name="birthDate">Дата рождения бегуна</param>
        /// <param name="avatarImage">Аватар бегуна</param>
        /// <param name="userId">ID пользователя</param>
        /// <param name="countryId">ID страны</param>
        /// <param name="charityId">ID благотворительной организации</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении нового спортсмена") - если произошла ошибка
        /// </returns>
        public bool AddNewRunner(DateTime birthDate, byte[] avatarImage, int userId, int countryId, int charityId)
        {
            try
            {
                runners newRunner = new runners
                {
                    runner_birthdate = birthDate,
                    user_id = userId,
                    country_id = countryId,
                    charity_id = charityId
                };
                if (avatarImage != null)
                {
                    newRunner.runner_image = avatarImage;
                }
                db.context.runners.Add(newRunner);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении нового спортсмена");
            }
        }
        /// <summary>
        /// Получение ID бегуна
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>
        /// ID бегуна
        /// </returns>
        public int GetRunnerId(int userId)
        {
            try
            {
                return GetRunners().Where(x => x.user_id == userId).FirstOrDefault().runner_id;
            }
            catch
            {
                throw new Exception("Ошибка при поиске ID!");
            }
        }
        /// <summary>
        /// Получение данных о бегунах
        /// </summary>
        /// <returns>
        /// Лист с данными о бегунах
        /// </returns>
        public List<runners> GetRunners()
        {
            return db.context.runners.ToList();
        }
        /// <summary>
        /// Получение информации о бегуне
        /// </summary>
        /// <param name="runnerId">ID бегуна</param>
        /// <returns>
        /// Объект с данными о бегуне
        /// </returns>
        public runners GetRunnerInfo(int runnerId)
        {
            try
            {
                return GetRunners().Where(x => x.runner_id == runnerId).FirstOrDefault();
            }
            catch
            {
                throw new Exception("Oшибка при выборе данных!");
            }
        }
        /// <summary>
        /// Обновление данных бегуна
        /// </summary>
        /// <param name="email">Email бегуна</param>
        /// <param name="firstname">Имя бегуна</param>
        /// <param name="lastname">Фамилия бегуна</param>
        /// <param name="othername">Отчество бегуна</param>
        /// <param name="genderCode">Код пола</param>
        /// <param name="birthdate">Дата рождения бегуна</param>
        /// <param name="countryId">ID страны</param>
        /// <param name="runnerImage">Аватар бегуна</param>
        /// <param name="password">Пароль бегуна</param>
        /// <returns>
        /// true - если данные обновлены успешно
        /// Exception("Произошла ошибка при изменении данных бегуна") - если при обновлении произошла ошибка
        /// </returns>
        public bool UpdateRunnerInfo(string email, string firstname, string lastname, string othername, string genderCode, DateTime birthdate, int countryId, byte[] runnerImage, string password)
        {
            try
            {
                runners currentRunner = db.context.runners.Where(x => x.users.user_email == email).FirstOrDefault();

                if (userObj.UpdateUserInfo(email, firstname, lastname, othername, genderCode, password))
                {
                    currentRunner.runner_birthdate = birthdate;
                    currentRunner.country_id = countryId;
                    currentRunner.runner_image = runnerImage;
                    db.context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при изменении данных бегуна");

            }
        }

    }
}
