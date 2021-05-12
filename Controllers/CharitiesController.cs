using MarathonSkills.Models;
using System;
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

        /// <summary>
        /// Добавление новой благотворительной организации
        /// </summary>
        /// <param name="charityLogo">Логотип организации</param>
        /// <param name="charityName">Название</param>
        /// <param name="descryption">Описание</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns>
        public bool AddNewCharity(byte[] charityLogo, string charityName, string descryption)
        {
            try
            {
                charities newCharity = new charities
                {
                    charity_logo = charityLogo,
                    charity_name = charityName,
                    charity_description = descryption
                };
                db.context.charities.Add(newCharity);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }
        }

        /// <summary>
        /// Изменение информации благотворительной организации
        /// </summary>
        /// <param name="charityLogo">Логотип оргпнизации</param>
        /// <param name="charityName">Название</param>
        /// <param name="descryption">Описание</param>
        /// <param name="charity">Старые данные благотворительной организации</param>
        /// <returns>
        /// true - если обновление произошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произоша ошибка
        /// </returns>
        public bool EditCharity(byte[] charityLogo, string charityName, string descryption, charities charity)
        {
            try
            {
                charities currentCharity = db.context.charities.Where(
                    x => x.charity_name == charity.charity_name && x.charity_description == charity.charity_description
                    ).FirstOrDefault();
                currentCharity.charity_logo = charityLogo;
                currentCharity.charity_name = charityName;
                currentCharity.charity_description = descryption;
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }
    }
}
