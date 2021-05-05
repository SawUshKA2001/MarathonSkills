using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    /// <summary>
    /// Логика взаимодействия с БД для таблицы event_reviews
    /// </summary>
    public class EventReviewsController
    {
        readonly Core db = new Core();

        /// <summary>
        /// Получение отзывов
        /// </summary>
        /// <returns>
        /// Лист с отзывами
        /// </returns>
        public List<event_reviews> GetReviews()
        {
            return db.context.event_reviews.ToList();
        }

        /// <summary>
        /// Добавление нового отзыва
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="eventId">ID забега</param>
        /// <param name="rating">Оценка забега</param>
        /// <param name="reviewText"> Текст отзыва</param>
        /// <returns></returns>
        public bool AddNewReview(int userId, int eventId, int rating, string reviewText)
        {
            try
            {
                event_reviews review = new event_reviews
                {
                    user_id = userId,
                    event_id = eventId,
                    event_review_mark = rating,
                    event_review_description = reviewText,
                    event_review_date = DateTime.Now
                };

                db.context.event_reviews.Add(review);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при создании отзыва!");
            }
        }
    }
}
