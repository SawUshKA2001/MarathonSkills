using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarathonSkills.Controllers;
using System.Linq;
using MarathonSkills.Models;

namespace MarathonSkillsControllersUnitTests
{
    [TestClass]
    public class CharitiesControllerTests
    {
        CharitiesController charObj = new CharitiesController();
        Core db = new Core();
        [TestMethod]
        public void GetCharities_DataFromDB_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            bool result = true;
            //Act
            if (charObj.GetCharities().Count() <= 0)
            {
                result = false;
            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddNewCharity_CorrectDataInserted_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            bool result = false;
            string name = "Тестовая организация";
            string descryption = "Описание";
            int countBeforeAdding = charObj.GetCharities().Count();
            //Act
            result = charObj.AddNewCharity(null, name, descryption);
            charObj = new CharitiesController();
            int countAfterAdding = charObj.GetCharities().Count();
            charities testedCharity = db.context.charities.Where(x => x.charity_name == name && x.charity_description == descryption).FirstOrDefault();
            db.context.charities.Remove(testedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.AreEqual(countBeforeAdding+1, countAfterAdding);
        }
        [TestMethod]
        public void EditCharity_CorrectDataInserted_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            bool result = false;
            string name = "Тестовая организация";
            string descryption = "Описание";
            charObj.AddNewCharity(null, name, descryption);
            charObj = new CharitiesController();
            charities testedCharity = db.context.charities.Where(x => x.charity_name == name && x.charity_description == descryption).FirstOrDefault();
            //Act
            name = "Новое имя";
            descryption = "Новое описание";
            result = charObj.EditCharity(null,name,descryption, testedCharity);
            db.context.charities.Remove(testedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
    }
}
