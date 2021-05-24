using System;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class MarathonsControllerTest
    {
        MarathonsController donObj = new MarathonsController();
        [TestMethod]
        public void GetCurrentMarathonInfo_GetDbData_trueReturned()
        {
            //Arrange
            donObj = new MarathonsController();
            //Act
            bool result = donObj.GetCurrentMarathonInfo() != null;
            //Assert    
            Assert.IsTrue(result);
        }

    }
}
