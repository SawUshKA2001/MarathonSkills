using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views.MoreAboutPages
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutMenuPage.xaml
    /// </summary>
    public partial class MoreAboutMenuPage : Page
    {
        /// <summary>
        /// Инициализация элементов страницы MoreAboutMenuPage
        /// </summary>
        public MoreAboutMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку BMICalculatorButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMICalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BmiCalculatorPage());
        }
        /// <summary>
        /// Нажатие на кнопку EventResultsButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventResultsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MoreAboutEventResultsPage());
        }
        /// <summary>
        /// Нажатие на кнопку CheritiesButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheritiesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MoreAboutCharitiesPage());
        }
    }
}
