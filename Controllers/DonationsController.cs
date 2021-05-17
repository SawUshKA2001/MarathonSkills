using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы donations
    /// </summary>
    public class DonationsController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о пожертвованиях
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о пожертвованиях
        /// </returns>
        public List<donations> GetDonations()
        {
            return db.context.donations.ToList();
        }

        /// <summary>
        /// Получение пожертвований для конкретного бегуна
        /// </summary>
        /// <param name="runnerId">
        /// ID бегуна
        /// </param>
        /// <returns>
        /// Возвращает лист с данными о пожертвованиях
        /// </returns>
        public List<donations> GetCurrentRunnerDonations(int runnerId)
        {
            return GetDonations().Where(x => x.runner_id == runnerId).ToList();
        }

        /// <summary>
        /// Добавление нового пожертвования
        /// </summary>
        /// <param name="donationAmount">Сумма пожертвования</param>
        /// <param name="firstName">Имя донора</param>
        /// <param name="lastName">Фамилия донора</param>
        /// <param name="otherName">Отчество донора</param>
        /// <param name="runnerId">ID бегуна</param>
        /// <returns>
        /// Возвращает:
        /// true - если добавление произошло успешно
        /// Exception("Произошла ошибка при совершении пожертвования!") - если при добавлении произошла ошибка
        /// </returns>
        public bool AddNewDonation(int donationAmount, string firstName, string lastName, string otherName, int runnerId)
        {
            try
            {
                donations donation = new donations
                {
                    donation_amount = donationAmount,
                    donator_firstname = firstName,
                    donator_lastname = lastName,
                    donator_othername = otherName,
                    runner_id = runnerId
                };
                db.context.donations.Add(donation);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при совершении пожертвования!");
            }
        }
    }
}
