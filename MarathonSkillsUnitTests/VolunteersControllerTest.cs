using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class VolunteersControllerTest
    {
        VolunteersController volObj = new VolunteersController();
        Core db = new Core();
        [TestMethod]
        public void GetVolunteers_GetDbData_trueReturned()
        {
            //Arrange
            volObj = new VolunteersController();
            //Act
            bool result = volObj.GetVolunteers().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void AddNewVolunteer_CorrectDataInserted_trueReturned()
        {
            //Arrange
            volObj = new VolunteersController();
            bool result = false;
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            string genderCode = "M";
            int countryId = 1;
            int countBefore = volObj.GetVolunteers().Count();
            //Act
            result = volObj.AddNewVolunteer(fName,lName,oName,birthDate,countryId,genderCode);
            volObj = new VolunteersController();
            int countAfter = volObj.GetVolunteers().Count();
            if (countAfter == countBefore + 1)
            {
                result = true;
            }
            db = new Core();
            volunteers addedVolunteer = db.context.volunteers.Where
                (x => x.volunteer_firstname == fName && x.volunteer_lastname == lName && x.volunteer_othername == oName)
                .FirstOrDefault();
            db.context.volunteers.Remove(addedVolunteer);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewVolunteer_NullDataInserted_falseReturned()
        {
            //Arrange
            volObj = new VolunteersController();
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            string fName = null;
            string lName = null;
            string oName = null;
            string genderCode = null;
            int countryId = 0;
            //Act
            Action actAction=() => volObj.AddNewVolunteer(fName, lName, oName, birthDate, countryId, genderCode);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateVolunteer_CorrectDataInserted_trueReturned()
        {
            //Arrange
            db = new Core();
            volObj = new VolunteersController();
            bool result = false;
            DateTime birthDate = Convert.ToDateTime("2001-11-23");
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            string genderCode = "M";
            int countryId = 1;
            int countBefore = volObj.GetVolunteers().Count();
            result = volObj.AddNewVolunteer(fName, lName, oName, birthDate, countryId, genderCode);
            volObj = new VolunteersController();
            volunteers addedVolunteer = db.context.volunteers.Where
                (x => x.volunteer_firstname == fName && x.volunteer_lastname == lName && x.volunteer_othername == oName)
                .FirstOrDefault();
            fName = "newName";
            lName = "newLName";
            oName = "newOName";
            genderCode = "W";
            //Act
            result = volObj.UpdateVolunteer(fName,lName,oName,birthDate,countryId,genderCode,addedVolunteer);
            db = new Core();
            addedVolunteer = db.context.volunteers.Where
                (x => x.volunteer_firstname == fName && x.volunteer_lastname == lName && x.volunteer_othername == oName)
                .FirstOrDefault();
            db.context.volunteers.Remove(addedVolunteer);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

    }
}
