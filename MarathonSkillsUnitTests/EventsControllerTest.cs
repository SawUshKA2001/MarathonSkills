using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class EventsControllerTest
    {
        Core db = new Core();
        EventsController eventObj = new EventsController();
        [TestMethod]
        public void GetDonations_GetDbData_trueReturned()
        {
            //Arrange
            eventObj = new EventsController();
            //Act
            bool result = eventObj.GetEvents().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }
    }
}
