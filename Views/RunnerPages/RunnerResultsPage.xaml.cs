using MarathonSkills.Controllers;
using MarathonSkills.Models;
using System.Windows.Controls;

namespace MarathonSkills.Views.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerResultsPage.xaml
    /// </summary>
    public partial class RunnerResultsPage : Page
    {
        readonly EventResultsController resObj = new EventResultsController();
        readonly RunnersController runObj = new RunnersController();
        readonly UsersController userObj = new UsersController();
        public RunnerResultsPage()
        {
            InitializeComponent();

            ResultsDatagrid.ItemsSource = resObj.GetCurrentRunnerResults(runObj.GetRunnerId(userObj.GetUserId(Manager.CurrentUser)));
        }
    }
}
