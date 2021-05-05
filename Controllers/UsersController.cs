using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы users
    /// </summary>
    public class UsersController
    {
        readonly Core db = new Core();

        /// <summary>
        /// Получение данных всех пользователей из БД
        /// </summary>
        /// <returns>
        /// Возвращает массив с данными пользователей
        /// </returns>
        public List<users> GetUsers()
        {
            List<users> userList = db.context.users.ToList();
            return userList;
        }

        /// <summary>
        /// Авторизация пользователя в приложении
        /// </summary>
        /// <param name="userLogin">
        /// Входная строка содержащая Email пользователя
        /// </param>
        /// <param name="userPassword">
        /// Входная строка содержащая пароль пользователя
        /// </param>
        /// <returns>
        /// Возвращает роль авторизуемого пользователя
        /// </returns>
        public int UserAuth(string userLogin, string userPassword)
        {
            List<users> currentUser = GetUsers().Where(x => x.user_email == userLogin && x.user_password == userPassword).ToList();
            if (currentUser.Count() != 0)
            {
                Manager.CurrentUser = currentUser.First().user_email;
                return currentUser.First().role_id;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Получение ID пользователя
        /// </summary>
        /// <param name="userEmail">
        /// Входная строка содержащая Email пользователя
        /// </param>
        /// <returns>
        /// Возвращает ID пользователя
        /// </returns>
        public int GetUserId(string userEmail)
        {
            return GetUsers().Where(x => x.user_email == userEmail).FirstOrDefault().user_id;
        }

        /// <summary>
        /// Добавление нового пользователя в БД
        /// </summary>
        /// <param name="userEmail">Входная строка содержащая Email пользователя</param>
        /// <param name="userFirstName">Входная строка содержащая имя пользователя</param>
        /// <param name="userLastName">Входная строка содержащая фамилию пользователя</param>
        /// <param name="userOtherName">Входная строка содержащая отчество пользователя</param>
        /// <param name="genderCode">Входная строка содержащая код пола пользователя</param>
        /// <param name="roleId">ID роли пользователя</param>
        /// <param name="userPassword">Пароль пользователя</param>
        /// <returns>
        /// Возврашает ID добаленного пользователя
        /// </returns>
        public int AddUser(string userEmail, string userFirstName, string userLastName, string userOtherName, string genderCode, int roleId, string userPassword)
        {
            try
            {
                users newUser = new users
                {
                    user_email = userEmail,
                    user_firstname = userFirstName,
                    user_lastname = userLastName,
                    user_othername = userOtherName,
                    gender_code = genderCode,
                    role_id = roleId,
                    user_password = userPassword
                };

                db.context.users.Add(newUser);
                db.context.SaveChanges();

                return GetUserId(userEmail);
            }
            catch
            {
                throw new Exception("Произошла ошибка при добалении нового пользователя!");
            }
        }

        /// <summary>
        /// Проверка Email на совпадение в БД
        /// </summary>
        /// <param name="checkedEmail">
        /// Проверяемый Email
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если совпадений не найдено
        /// false - если найдено совпадение
        /// </returns>
        public bool CheckEmailDuplication(string checkedEmail)
        {
            int usersCount = GetUsers().Where(x => x.user_email == checkedEmail).Count();
            if (usersCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Получение данных о пользователе
        /// </summary>
        /// <param name="userEmail">
        /// Email пользователя
        /// </param>
        /// <returns>
        /// Возвращает объект таблицы users с данными о выбранном пользователе
        /// </returns>
        public users GetUserInfo(string userEmail)
        {
            return GetUsers().Where(x => x.user_email == userEmail).FirstOrDefault();
        }

        /// <summary>
        /// Обновление данных пользователя в БД
        /// </summary>
        /// <param name="email">
        /// Email пользователя
        /// </param>
        /// <param name="firstname">
        /// Имя пользователя
        /// </param>
        /// <param name="lastname">
        /// Фамилия пользователя
        /// </param>
        /// <param name="othername">
        /// Отчество пользователя
        /// </param>
        /// <param name="genderCode">
        /// Код пола пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если обновление произошло успешно
        /// Exception("Ошибка при изменении данных пользователя.") - если при обновлении произошла ошибка
        /// </returns>
        public bool UpdateUserInfo(string email, string firstname, string lastname, string othername, string genderCode, string password)
        {
            try
            {
                users currentUser = db.context.users.Where(x => x.user_email == email).FirstOrDefault();

                currentUser.user_firstname = firstname;
                currentUser.user_lastname = lastname;
                currentUser.user_othername = othername;

                currentUser.gender_code = genderCode;

                if (!String.IsNullOrWhiteSpace(password))
                {
                    currentUser.user_password = password;
                }

                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка при изменении данных пользователя.");
            }
        }

        /// <summary>
        /// Получении данных пользователей по роли
        /// </summary>
        /// <param name="roleId">
        /// Роль пользователей
        /// </param>
        /// <returns>
        /// Возвращает лист данных пользователей
        /// </returns>
        public List<users> GetUsersByRole(int roleId)
        {
            return GetUsers().Where(x => x.role_id == roleId).ToList();
        }
    }
}
