using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarathonSkills.Models;
using MarathonSkills.Controllers;
using System.Linq;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class CharitiesControllerTest
    {
        CharitiesController charObj = new CharitiesController();
        Core db = new Core();
        [TestMethod]
        public void GetCharities_GetDbData_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            //Act
            bool result = charObj.GetCharities().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewCharity_AddingCorrectData_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            byte[] charityLogo = null;
            string name = "Название";
            string descryption = "Описание";
            int countBefore = charObj.GetCharities().Count();
            //Act
            bool result = charObj.AddNewCharity(charityLogo, name, descryption);
            charObj = new CharitiesController();
            int countAfter = charObj.GetCharities().Count(); 
            if(countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            charities addedCharity = db.context.charities.Where
                (x => x.charity_name == name && x.charity_description == descryption)
                .FirstOrDefault();
            db.context.charities.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewCharity_AddingNullData_ExceptionReturned()
        {
            //Arrange
            byte[] charityLogo = null;
            string name = null;
            string descryption = null;
            //Act
            charObj = new CharitiesController();
            Action actAction = () => charObj.AddNewCharity(charityLogo, name, descryption);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }


        [TestMethod]
        public void EditCharity_EdititingCorrectData_trueReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            byte[] charityLogo = null;
            string name = "Название";
            string descryption = "Описание";
            bool result = charObj.AddNewCharity(charityLogo, name, descryption);
            charities editableCharity = charObj.GetCharities().Where(x => x.charity_name == name && x.charity_description == descryption).FirstOrDefault();
            int addedId = editableCharity.charity_id;
            name = "Новое название";
            descryption = "Новое описание";
            //Act
            charObj = new CharitiesController();
            result = charObj.EditCharity(charityLogo, name, descryption, editableCharity);

            if(charObj.GetCharities().Where(x=>x.charity_id == addedId).FirstOrDefault().charity_name != name || charObj.GetCharities().Where(x => x.charity_id == addedId).FirstOrDefault().charity_description != descryption)
            {
                result = false;
            }

            db = new Core();
            charities addedCharity = db.context.charities.Where
                (x => x.charity_id == addedId)
                .FirstOrDefault();
            db.context.charities.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EditCharity_EdititingNullData_ExceptionReturned()
        {
            //Arrange
            charObj = new CharitiesController();
            byte[] charityLogo = null;
            string name = "Название";
            string descryption = "Описание";
            bool result = charObj.AddNewCharity(charityLogo, name, descryption);
            charities editableCharity = charObj.GetCharities().Where(x => x.charity_name == name && x.charity_description == descryption).FirstOrDefault();
            int addedId = editableCharity.charity_id;
            name = null;
            descryption = null;
            //Act
            charObj = new CharitiesController();
            Action actAction = () => charObj.EditCharity(charityLogo, name, descryption, editableCharity);

            db = new Core();
            charities addedCharity = db.context.charities.Where
                (x => x.charity_id == addedId)
                .FirstOrDefault();
            db.context.charities.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
    }
}
