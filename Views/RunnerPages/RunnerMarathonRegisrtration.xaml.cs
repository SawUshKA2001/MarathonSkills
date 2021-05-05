using MarathonSkills.Controllers;
using MarathonSkills.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerMarathonRegisrtration.xaml
    /// </summary>
    public partial class RunnerMarathonRegisrtration : Page
    {
        readonly EventsController eventObj = new EventsController();
        readonly EventRegistrationController regObj = new EventRegistrationController();
        readonly RunnersController runObj = new RunnersController();
        readonly UsersController userObj = new UsersController();

        public RunnerMarathonRegisrtration()
        {
            InitializeComponent();
            ContentStackPanel.Visibility = Visibility.Collapsed;

            EventComboBox.ItemsSource = eventObj.GetEvents().Where(x => x.event_is_finished == false);
            EventComboBox.DisplayMemberPath = "event_name";
            EventComboBox.SelectedValuePath = "event_id";
        }

        private void EventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int eventId = Convert.ToInt32(EventComboBox.SelectedValue);
            ContentStackPanel.Visibility = Visibility.Visible;
            MarathonInfoTextBlock.Text = eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().marathons.marathon_name;
            DateTimeTextBlock.Text = eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().event_datetime.ToString("d");
            NameTextBlock.Text = eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().event_name;
            PlaceTextBlock.Text = eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().marathons.countries.country_name + ", "
                + eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().marathons.marathon_city_name;
            TypeTextBlock.Text = eventObj.GetEvents().Where(x => x.event_id == eventId).FirstOrDefault().event_types.event_type_name;
        }

        private void MarathonRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EventComboBox.SelectedValue != null)
                {
                    bool registrationResult = regObj.AddNewRegistration(Convert.ToInt32(EventComboBox.SelectedValue), runObj.GetRunnerId(userObj.GetUserId(Manager.CurrentUser)));
                    if (registrationResult)
                    {
                        MessageBox.Show("Регистрация на выбранный марафон прошла успешно!");
                    }
                    else if (!registrationResult)
                    {
                        MessageBox.Show("Вы уже зарегестрированы на данный забег!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
