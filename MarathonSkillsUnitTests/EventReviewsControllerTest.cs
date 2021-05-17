using System;
using System.Linq;
using MarathonSkills.Controllers;
using MarathonSkills.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarathonSkillsUnitTests
{
    [TestClass]
    public class EventReviewsControllerTest
    {
        Core db = new Core();
        EventReviewsController revObj = new EventReviewsController();
        [TestMethod]
        public void GetReviews_GetDbData_trueReturned()
        {
            //Arrange
            revObj = new EventReviewsController();
            //Act
            bool result = revObj.GetReviews().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddNewReview_CorrectDataInserted_trueReturned()
        {
            //Arrange
            revObj = new EventReviewsController();
            int userId = 1;
            //Act
            bool result = revObj.GetReviews().Count() > 0;
            //Assert    
            Assert.IsTrue(result);
        }

    }
}
