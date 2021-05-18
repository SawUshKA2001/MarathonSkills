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
            Action actAction =()=> runObj.GetRunnerId(userId);
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


    }
}
