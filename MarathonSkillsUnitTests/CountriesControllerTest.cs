using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarathonSkills.Controllers;
using System.Linq;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class CountriesControllerTest
    {
        [TestMethod]
        public void GetCountries_GetDbData_trueReturned()
        {
            //Arrange
            CountriesController countryObj = new CountriesController();
            //Act
            bool result = countryObj.GetCountries().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
    }
}
