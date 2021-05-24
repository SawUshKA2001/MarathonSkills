using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarathonSkillsLibrary
{
    /// <summary>
    /// Логика проверки строк 
    /// </summary>
    public class StringCheckClass
    {
        Regex regex;
        Match match;
        /// <summary>
        /// Проверка правильности Email
        /// </summary>
        /// <param name="emailString">Email</param>
        /// <returns>
        /// true - если Email верный
        /// false - если Email неверный
        /// </returns>
        public bool EmailCheck(string emailString)
        {
            regex = new Regex(@"^[_a-z0-9-\+-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$");
            match = regex.Match(emailString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка правильности пароля
        /// </summary>
        /// <param name="passwordString">Пароль</param>
        /// <returns>
        /// true - если пароль верный
        /// false - если пароль неверный
        /// </returns>
        public bool PasswordCheck(string passwordString)
        {
            regex = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            match = regex.Match(passwordString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка правильности имени
        /// </summary>
        /// <param name="nameString">Имя</param>
        /// <returns>
        /// true - если имя верное
        /// false - если имя неверное
        /// </returns>
        public bool NameCheck(string nameString)
        {
            regex = new Regex(@"^[а-яА-Я\sa-zA-Z]{3,}$");
            match = regex.Match(nameString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка правильности номера карты
        /// </summary>
        /// <param name="numberString">Номер карты</param>
        /// <returns>
        /// true - если номер вернен
        /// false - если номер невернен
        /// </returns>
        public bool CardNumberCheck(string numberString)
        {
            regex = new Regex(@"^[\d]{4}[\s]?[\d]{4}[\s]?[\d]{4}[\s]?[\d]{4}$");
            match = regex.Match(numberString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка месяца карты
        /// </summary>
        /// <param name="monthString">Месяц</param>
        /// <returns>
        /// true - если месяц вернен
        /// false - если месяц невернен
        /// </returns>
        public bool CardMonthCheck(string monthString)
        {
            regex = new Regex(@"^[\d]{2}$");
            match = regex.Match(monthString);
            if (match.Success && Convert.ToInt32(monthString)<=12)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Проверка год карты
        /// </summary>
        /// <param name="year">Год</param>
        /// <returns>
        /// true - если год вернен
        /// false - если год невернен
        /// </returns>
        public bool CardYearCheck(int year)
        {
            regex = new Regex(@"^20[\d]{2}$");
            match = regex.Match(year.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Проверка cvc карты
        /// </summary>
        /// <param name="cvc">Год</param>
        /// <returns>
        /// true - если cvc вернен
        /// false - если cvc невернен
        /// </returns>
        public bool CvcCheck(int cvc)
        {
            regex = new Regex(@"^[\d]{3}$");
            match = regex.Match(cvc.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
