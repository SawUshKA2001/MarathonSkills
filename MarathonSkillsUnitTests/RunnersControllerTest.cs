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


    }
}
