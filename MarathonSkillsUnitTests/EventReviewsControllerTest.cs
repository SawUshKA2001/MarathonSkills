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
            int eventId = 2;
            int rating = 5;
            string reviewText = "Тестовый текст отзыва";
            int countBefore = revObj.GetReviews().Count();
            //Act
            bool result = revObj.AddNewReview(userId, eventId, rating, reviewText);
            revObj = new EventReviewsController();
            int countAfter = revObj.GetReviews().Count();
            if (countBefore + 1 != countAfter)
            {
                result = false;
            }
            db = new Core();
            event_reviews addedReview = db.context.event_reviews.Where
                (x => x.user_id == userId && x.event_id == eventId && x.event_review_mark == rating && x.event_review_description == reviewText)
                .FirstOrDefault();
            db.context.event_reviews.Remove(addedReview);
            db.context.SaveChanges();
            //Assert    
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddNewReview_NullDataInserted_Returned()
        {
            //Arrange
            revObj = new EventReviewsController();
            int userId = 0;
            int eventId = 0;
            int rating = 0;
            string reviewText = String.Empty;
            //Act
            void actAction() => revObj.AddNewReview(userId, eventId, rating, reviewText);
            //Assert    
            Assert.ThrowsException<Exception>(actAction);
        }

    }
}
