using MarathonSkills.Controllers;
using MarathonSkills.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Views.ViewerPages
{
    /// <summary>
    /// Логика взаимодействия для ViewerAddReviewPage.xaml
    /// </summary>
    public partial class ViewerAddReviewPage : Page
    {
        readonly EventReviewsController revObj = new EventReviewsController();
        readonly EventsController eventObj = new EventsController();
        readonly UsersController userObj = new UsersController();
        int rating;
        public ViewerAddReviewPage()
        {
            InitializeComponent();
            rating = 5;

            EventComboBox.ItemsSource = eventObj.GetEvents();
            EventComboBox.DisplayMemberPath = "event_name";
            EventComboBox.SelectedValuePath = "event_id";
            EventComboBox.SelectedIndex = 0;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            rating = Convert.ToInt32(button.Tag);
            Console.WriteLine(rating);
        }

        private string SetBorders()
        {
            string errorsString = String.Empty;
            ReviewDescriptyonTextBox.BorderBrush = Brushes.Black;
            ReviewDescriptyonTextBox.BorderThickness = new Thickness(1);
            if (String.IsNullOrWhiteSpace(ReviewDescriptyonTextBox.Text))
            {
                ReviewDescriptyonTextBox.BorderBrush = Brushes.Red;
                ReviewDescriptyonTextBox.BorderThickness = new Thickness(3);
                errorsString += "Не заполнено поле комментария!";
            }
            return errorsString;
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                try
                {
                    if (revObj.AddNewReview(userObj.GetUserId(Manager.CurrentUser), Convert.ToInt32(EventComboBox.SelectedValue), rating, ReviewDescriptyonTextBox.Text))
                    {
                        MessageBox.Show("Ваш отзыв успешно сохранён!");
                        this.NavigationService.GoBack();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(errors);
            }
        }
    }
}
