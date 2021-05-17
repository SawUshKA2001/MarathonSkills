using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class GendersControllerTest
    {
        Core db = new Core();
        GendersController genObj = new GendersController();
        [TestMethod]
        public void GetGenders_GetDbData_trueReturned()
        {
            //Arrange
            genObj = new GendersController();
            //Act
            bool result = genObj.GetGenders().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }

    }
}
