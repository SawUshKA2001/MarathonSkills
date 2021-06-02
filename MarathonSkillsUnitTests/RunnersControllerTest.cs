using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class RunnersControllerTest
    {
        Core db = new Core();
        RunnersController runObj = new RunnersController();
        UsersController userObj = new UsersController();

        [TestMethod]
        public void GetRunners_GetDbData_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            //Act
            bool result = runObj.GetRunners().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void GetRunnerId_RealRunnerIdInserted_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            int userId = 5;
            //Act
            int result = runObj.GetRunnerId(userId);
            //Assert
            Assert.AreEqual(1,result);
        }
        
        [TestMethod]
        public void GetRunnerId_WrongRunnerIdInserted_ExceptionReturned()
        {
            //Arrange
            runObj = new RunnersController();
            int userId = 0;
            //Act
            void actAction() => runObj.GetRunnerId(userId);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        
        [TestMethod]
        public void GetRunnerInfo_RealRunnerIdInserted_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            int runnerId = 1;
            bool result = false;
            //Act
            if (runObj.GetRunnerInfo(runnerId) != null)
            {
                result = true;
            }
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void GetRunnerInfo_WrongRunnerIdInserted_ExceptionReturned()
        {
            //Arrange
            runObj = new RunnersController();
            int runnerId = 0;
            bool result = false;
            //Act
            if (runObj.GetRunnerInfo(runnerId) != null)
            {
                result = true;
            }
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddNewRunner_CorrectDataInserted_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            byte[] avatarImage = null;
            int userId = userObj.AddUser("email.adress@email.com","Firstname","Lastname","Othername","M",2,"password");
            int countryId = 1;
            int charityId = 1;
            int countBefore = runObj.GetRunners().Count();
            //Act
            bool result = runObj.AddNewRunner(birthDate, avatarImage, userId, countryId, charityId);
            runObj = new RunnersController();
            if(countBefore+1!= runObj.GetRunners().Count())
            {
                result = false;
            }
            db = new Core();
            users addedUser = db.context.users.Where
                (x => x.user_id == userId)
                .FirstOrDefault();
            runners addedRunner = db.context.runners.Where
                (x => x.user_id == userId)
                .FirstOrDefault();
            db.context.runners.Remove(addedRunner);
            db.context.users.Remove(addedUser);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddNewRunner_NullDataInserted_falseReturned()
        {
            //Arrange
            runObj = new RunnersController();
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            byte[] avatarImage = null;
            int userId = 0;
            int countryId = 0;
            int charityId = 0;
            int countBefore = runObj.GetRunners().Count();
            //Act
            Action actAction =()=> runObj.AddNewRunner(birthDate, avatarImage, userId, countryId, charityId);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateRunnerInfo_CorrectDataInserted_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            byte[] avatarImage = null;
            string email = "email.adress@email.com";
            string firstName = "Firstname";
            string lastName = "Lastname";
            string otherName = "Othername";
            string genderCode = "M";
            string password = "password";
            int userId = userObj.AddUser(email, firstName, lastName, otherName, genderCode, 2, password);
            int countryId = 1;
            int charityId = 1;
            bool result = runObj.AddNewRunner(birthDate, avatarImage, userId, countryId, charityId);
            runObj = new RunnersController();
            int countBefore = runObj.GetRunners().Count();
            firstName = "newFirstname";
            lastName = "newLastname";
            otherName = "newOthername";
            genderCode = "W";
            password = "newPassword";
            //Act
            result = runObj.UpdateRunnerInfo(email, firstName,lastName, otherName, genderCode, birthDate, countryId, avatarImage, password);
            runObj = new RunnersController();
            if (countBefore != runObj.GetRunners().Count())
            {
                result = false;
            }
            db = new Core();
            users addedUser = db.context.users.Where
                (x => x.user_id == userId)
                .FirstOrDefault();
            runners addedRunner = db.context.runners.Where
                (x => x.user_id == userId)
                .FirstOrDefault();
            db.context.runners.Remove(addedRunner);
            db.context.users.Remove(addedUser);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateRunnerInfo_NullDataInserted_trueReturned()
        {
            //Arrange
            runObj = new RunnersController();
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            byte[] avatarImage = null;
            string email = "email.adress@email.com";
            string firstName = "Firstname";
            string lastName = "Lastname";
            string otherName = "Othername";
            string genderCode = "M";
            string password = "password";
            int userId = userObj.AddUser(email, firstName, lastName, otherName, genderCode, 2, password);
            int countryId = 1;
            int charityId = 1;
            bool result = runObj.AddNewRunner(birthDate, avatarImage, userId, countryId, charityId);
            runObj = new RunnersController();
            firstName = null;
            lastName = null;
            otherName = null;
            genderCode = null;
            password = null;
            //Act
            Action actAction = () => runObj.UpdateRunnerInfo(email, firstName, lastName, otherName, genderCode, birthDate, countryId, avatarImage, password);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
    }
}
