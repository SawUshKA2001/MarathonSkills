using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class EventRegistrationControllerTest
    {
        Core db = new Core();
        EventRegistrationController regObj = new EventRegistrationController();

        [TestMethod]
        public void GetRegistrations_GetDbData_trueReturned()
        {
            //Arrange
            regObj = new EventRegistrationController();
            //Act
            bool result = regObj.GetRegistrations().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void AddNewRegistration_CorrectDataInserted_trueReturned()
        {
            //Arrange
            regObj = new EventRegistrationController();
            int eventId = 2;
            int runnerId = 2;
            int countBefore = regObj.GetRegistrations().Count();
            //Act
            bool result = regObj.AddNewRegistration(eventId, runnerId);
            regObj = new EventRegistrationController();
            int countAfter = regObj.GetRegistrations().Count();
            if (countBefore + 1 != countAfter)
            {
                result = false;
            }
            db = new Core();
            event_registration addedRegistration = db.context.event_registration.Where
                (x => x.event_id == eventId && x.runner_id == runnerId)
                .FirstOrDefault();
            db.context.event_registration.Remove(addedRegistration);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddNewRegistration_DoubleDataInserted_falseReturned()
        {
            //Arrange
            regObj = new EventRegistrationController();
            int eventId = 2;
            int runnerId = 2;
            bool result = regObj.AddNewRegistration(eventId, runnerId);
            int countBefore = regObj.GetRegistrations().Count();
            //Act
            result = regObj.AddNewRegistration(eventId, runnerId);
            regObj = new EventRegistrationController();
            int countAfter = regObj.GetRegistrations().Count();
            if (countBefore + 1 == countAfter)
            {
                result = true;
            }
            db = new Core();
            event_registration addedRegistration = db.context.event_registration.Where
                (x => x.event_id == eventId && x.runner_id == runnerId)
                .FirstOrDefault();
            db.context.event_registration.Remove(addedRegistration);
            db.context.SaveChanges();
            //Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void AddNewRegistration_NullDataInserted_ExceptionReturned()
        {
            //Arrange
            regObj = new EventRegistrationController();
            int eventId = 0;
            int runnerId = 0;
            //Act
            void actAction() => regObj.AddNewRegistration(eventId, runnerId);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

    }
}
