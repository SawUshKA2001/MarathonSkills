using MarathonSkills.Controllers;
using System.Windows.Controls;

namespace MarathonSkills.Views.MoreAboutPages
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutCharitiesPage.xaml
    /// </summary>
    public partial class MoreAboutCharitiesPage : Page
    {
        readonly CharitiesController charObj = new CharitiesController();
        /// <summary>
        /// Инициализация элементов страницы MoreAboutCharitiesPage
        /// </summary>
        public MoreAboutCharitiesPage()
        {
            InitializeComponent();
            CharitiesListView.ItemsSource = charObj.GetCharities();
        }
    }
}
