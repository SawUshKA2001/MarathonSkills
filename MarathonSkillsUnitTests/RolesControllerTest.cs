using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class RolesControllerTest
    {
        Core db = new Core();
        RolesController roleObj = new RolesController();
        [TestMethod]
        public void GetRoles_GetDbData_trueReturned()
        {
            //Arrange
            roleObj = new RolesController();
            //Act
            bool result = roleObj.GetRoles().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }

    }
}
