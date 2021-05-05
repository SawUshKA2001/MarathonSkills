using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class UsersController
    {
        readonly Core db = new Core();

        public List<users> GetUsers()
        {
            List<users> userList = db.context.users.ToList();
            return userList;
        }

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

        public int GetUserId(string userEmail)
        {
            return GetUsers().Where(x => x.user_email == userEmail).FirstOrDefault().user_id;
        }

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

        public users GetUserInfo(string userEmail)
        {
            return GetUsers().Where(x => x.user_email == userEmail).FirstOrDefault();
        }

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

        public List<users> GetUsersByRole(int roleId)
        {
            return GetUsers().Where(x => x.role_id == roleId).ToList();
        }
    }
}
