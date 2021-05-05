using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class RunnersController
    {
        readonly Core db = new Core();
        readonly UsersController userObj = new UsersController();

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
        public int GetRunnerId(int userId)
        {
            return GetRunners().Where(x => x.user_id == userId).FirstOrDefault().runner_id;
        }
        public List<runners> GetRunners()
        {
            return db.context.runners.ToList();
        }
        public runners GetRunnerInfo(int runnerId)
        {
            return GetRunners().Where(x => x.runner_id == runnerId).FirstOrDefault();
        }
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
