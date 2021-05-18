using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class UsersControllerTest
    {
        Core db = new Core();
        UsersController userObj = new UsersController();

        [TestMethod]
        public void GetUsers_GetDbData_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            //Act
            bool result = userObj.GetUsers().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void UserAuth_AuthAdmin_oneReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "sawin.world@gmail.com";
            string password = "Sawerw12*";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 1);
        }
        [TestMethod]
        public void UserAuth_AuthCoordinator_twoReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "xomjak@yandex.ru";
            string password = "Artem12*";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 2);
        }
        [TestMethod]
        public void UserAuth_AuthRunner_threeReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "dima18@mail.ru";
            string password = "Dima12*";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 3);
        }
        
        [TestMethod]
        public void UserAuth_AuthViewer_fourReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "weerfd@bk.ru";
            string password = "Tert12*";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 4);
        }
        
        [TestMethod]
        public void UserAuth_AuthInvalid_zeroReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "broken@email";
            string password = "N0t4P4$$w0rd";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 0);
        }
        [TestMethod]
        public void GetUserId_CorrectEmailInserted_oneReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "sawin.world@gmail.com";
            //Act
            int userId = userObj.GetUserId(email);
            //Assert
            Assert.AreEqual(userId, 1);
        }
        [TestMethod]
        public void GetUserId_IncorrectEmailInserted_ExceptionReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "broken@email";
            //Act
            Action actAction =()=> userObj.GetUserId(email);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void CheckEmailDuplication_NotExistedEmailInserted_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "broken@email";
            //Act
            bool result = userObj.CheckEmailDuplication(email);
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CheckEmailDuplication_ExistedEmailInserted_falseReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "sawin.world@gmail.com";
            //Act
            bool result = userObj.CheckEmailDuplication(email);
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void GetUserInfo_RealUserEmailInserted_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "sawin.world@gmail.com";
            bool result = false;
            //Act
            if (userObj.GetUserInfo(email) != null)
            {
                result = true;
            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetUserInfo_NotUserEmailInserted_nullReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "broken@email";
            bool result = false;
            //Act
            if (userObj.GetUserInfo(email) != null)
            {
                result = true;
            }
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void GetUsersByRole_AdminRoleIdInserted_oneReturned()
        {
            //Arrange
            userObj = new UsersController();
            bool result = false;
            //Act
            if (userObj.GetUsersByRole(1).Count() == 1)
            {
                result = true;
            }
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddUser_CorrectDataInserted_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            bool result = false;
            string email = "totally.real@human.email";
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            string genderCode = "M";
            int roleId = 1;
            string password = "P4$$W0rd";
            int countBefore = userObj.GetUsers().Count();
            //Act
            int addedUserId = userObj.AddUser(email, fName, lName, oName, genderCode, roleId, password);
            userObj = new UsersController();
            int countAfter = userObj.GetUsers().Count();
            if(countAfter == countBefore + 1)
            {
                if(userObj.GetUserInfo(email).user_id == addedUserId)
                {
                    result = true;
                }
            }
            db = new Core();
            users addedUser = db.context.users.Where
                (x => x.user_id == addedUserId)
                .FirstOrDefault();
            db.context.users.Remove(addedUser);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddUser_nullDataInserted_ExceptionReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = null;
            string fName = null;
            string lName = null;
            string oName = null;
            string genderCode = null;
            int roleId = 0;
            string password = null;
            //Act
            Action actAction =()=> userObj.AddUser(email, fName, lName, oName, genderCode, roleId, password);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateUserInfo_CorrectDataInserted_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            bool result = false;
            string email = "totally.real@human.email";
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            string genderCode = "M";
            int roleId = 1;
            string password = "P4$$W0rd";
            int addedUserId = userObj.AddUser(email, fName, lName, oName, genderCode, roleId, password);
            fName = "Новое имя";
            lName = "Новое фамилия";
            oName = "Новое отчество";
            genderCode = "W";
            password = "n6W*Pa$$w0rd";
            //Act
            if (userObj.UpdateUserInfo(email, fName, lName, oName, genderCode, password))
            {
                userObj = new UsersController();

                if (userObj.GetUserInfo(email).user_firstname == fName
                    && userObj.GetUserInfo(email).user_lastname == lName
                    && userObj.GetUserInfo(email).user_othername == oName
                    && userObj.GetUserInfo(email).gender_code == genderCode
                    && userObj.GetUserInfo(email).role_id == roleId
                    && userObj.GetUserInfo(email).user_password == password)
                {
                    result = true;
                }
            }
            db = new Core();
            users addedUser = db.context.users.Where
                (x => x.user_id == addedUserId)
                .FirstOrDefault();
            db.context.users.Remove(addedUser);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void UpdateUserInfo_NullDataInserted_ExceptionReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "totally.real@human.email";
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            string genderCode = "M";
            int roleId = 1;
            string password = "P4$$W0rd";
            int addedUserId = userObj.AddUser(email, fName, lName, oName, genderCode, roleId, password);
            fName = null;
            lName = null;
            oName = null;
            genderCode = null;
            password = null;
            //Act
            Action actAction = ()=> userObj.UpdateUserInfo(email, fName, lName, oName, genderCode, password);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

    }
}
