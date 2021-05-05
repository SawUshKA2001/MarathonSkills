using MarathonSkills.Controllers;
using System.Linq;
using System.Windows.Controls;


namespace MarathonSkills.Views.ViewerPages
{
    /// <summary>
    /// Логика взаимодействия для ViewerSeeReviewsPage.xaml
    /// </summary>
    public partial class ViewerSeeReviewsPage : Page
    {
        readonly EventReviewsController revObj = new EventReviewsController();
        /// <summary>
        /// Инициализация страницы ViewerSeeReviewsPage
        /// </summary>
        public ViewerSeeReviewsPage()
        {
            InitializeComponent();
            ReviewsItemsControl.ItemsSource = revObj.GetReviews().OrderByDescending(x => x.event_review_date).Take(10);
        }
    }
}
