using MarathonSkills.Views;
using System.Windows;

namespace MarathonSkills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация элементов главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StartingPage());
        }
    }
}
