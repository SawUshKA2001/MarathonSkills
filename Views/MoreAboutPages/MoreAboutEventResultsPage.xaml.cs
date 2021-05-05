using MarathonSkills.Controllers;
using System;
using System.Windows.Controls;

namespace MarathonSkills.Views.MoreAboutPages
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutEventResultsPage.xaml
    /// </summary>
    public partial class MoreAboutEventResultsPage : Page
    {
        readonly EventResultsController resObj = new EventResultsController();
        readonly EventsController eventObj = new EventsController();
        public MoreAboutEventResultsPage()
        {
            InitializeComponent();
            EventComboBox.ItemsSource = eventObj.GetEvents();
            EventComboBox.DisplayMemberPath = "event_name";
            EventComboBox.SelectedValuePath = "event_id";
            EventComboBox.SelectedIndex = 0;
        }

        private void EventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultsDataGrid.ItemsSource = resObj.GetCurrentEventResults(Convert.ToInt32(EventComboBox.SelectedValue));
        }
    }
}
