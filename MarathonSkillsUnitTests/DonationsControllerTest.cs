using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using System.Linq;
using System.Collections.Generic;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class DonationsControllerTest
    {
        Core db = new Core();
        DonationsController donObj = new DonationsController();
        [TestMethod]
        public void GetDonations_GetDbData_trueReturned()
        {
            //Arrange
            donObj = new DonationsController();
            //Act
            bool result = donObj.GetDonations().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCurrentRunnerDonations_CorrectRunnerInserted_trueReturned()
        {
            //Arrange
            donObj = new DonationsController();
            int runnerId = 2;
            //Act
            bool result = donObj.GetCurrentRunnerDonations(runnerId).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCurrentRunnerDonations_IncorrectRunnerInserted_nullReturned()
        {
            //Arrange
            donObj = new DonationsController();
            int runnerId = -12;
            //Act
            List<donations> dons = donObj.GetCurrentRunnerDonations(runnerId);
            //Assert
            Assert.IsTrue(dons.Count() == 0);
        }

        [TestMethod]
        public void AddNewDonation_CorrectDataInserted_trueReturned()
        {
            //Arrange
            donObj = new DonationsController();
            int amount = 50;
            string fName = "Имя";
            string lName = "Фамилия";
            string oName = "Отчество";
            int runnerId = 2;
            int countBefore = donObj.GetDonations().Count();
            //Act
            bool result = donObj.AddNewDonation(amount, fName, lName, oName, runnerId);
            donObj = new DonationsController();
            int countAfter = donObj.GetDonations().Count();
            if (countBefore + 1 != countAfter)
            {
                result = false;
            }
            db = new Core();
            donations addedDonation = db.context.donations.Where
                (x => x.donator_firstname == fName && x.donator_lastname == lName && x.donator_othername == oName)
                .FirstOrDefault();
            db.context.donations.Remove(addedDonation);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddNewDonation_NullDataInserted_falseReturned()
        {
            //Arrange
            donObj = new DonationsController();
            int amount = 0;
            string fName = null;
            string lName = null;
            string oName = null;
            int runnerId = 0;
            //Act
            void actAction() => donObj.AddNewDonation(amount, fName, lName, oName, runnerId);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }


    }
}
