using MarathonSkills.Controllers;
using MarathonSkills.Models;
using MarathonSkillsLibrary;
using System.Windows.Controls;

namespace MarathonSkills.Views.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerCharityPage.xaml
    /// </summary>
    public partial class RunnerCharityPage : Page
    {
        readonly DonationsController donObj = new DonationsController();
        readonly UsersController userObj = new UsersController();
        readonly RunnersController runObj = new RunnersController();

        public RunnerCharityPage()
        {
            runners currentRunner = runObj.GetRunnerInfo(runObj.GetRunnerId(userObj.GetUserId(Manager.CurrentUser)));
            InitializeComponent();

            DonationsDataGrid.ItemsSource = donObj.GetCurrentRunnerDonations(runObj.GetRunnerId(userObj.GetUserId(Manager.CurrentUser)));

            DonationsSummLabel.Content = "Общая сумма пожертвований $" + currentRunner.AllDonationsAmount;

            CharityNameLabel.Content = currentRunner.charities.charity_name;
            SetCharityLogo(currentRunner.charities.charity_logo);
            CharityInfoTextBlock.Text = currentRunner.charities.charity_description;
        }

        private void SetCharityLogo(byte[] logo)
        {
            if (logo != null)
            {
                CharityLogoImage.Source = FileManagerClass.GetBytePhotoToImage(logo);
            }
        }
    }
}
