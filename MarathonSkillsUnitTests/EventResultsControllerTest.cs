using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class EventResultsControllerTest
    {
        EventResultsController resObj = new EventResultsController();
        [TestMethod]
        public void GetDonations_GetDbData_trueReturned()
        {
            //Arrange
            resObj = new EventResultsController();
            //Act
            bool result = resObj.GetResults().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetCurrentRunnerResults_CorrectRunnerInserted_trueReturned()
        {
            //Arrange
            resObj = new EventResultsController();
            int runnerId = 2;
            //Act
            bool result = resObj.GetCurrentRunnerResults(runnerId).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetCurrentRunnerResults_IncorrectRunnerInserted_nullReturned()
        {
            //Arrange
            resObj = new EventResultsController();
            int runnerId = -2;
            //Act
            bool result = resObj.GetCurrentRunnerResults(runnerId).Count() > 0;
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetCurrentEventResults_CorrectEventInserted_trueReturned()
        {
            //Arrange
            resObj = new EventResultsController();
            int eventId = 2;
            //Act
            bool result = resObj.GetCurrentEventResults(eventId).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetCurrentEventResults_InorrectEventInserted_nullReturned()
        {
            //Arrange
            resObj = new EventResultsController();
            int eventId = -2;
            //Act
            bool result = resObj.GetCurrentEventResults(eventId).Count() > 0;
            //Assert
            Assert.IsFalse(result);
        }
    }
}
