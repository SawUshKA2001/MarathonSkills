using MarathonSkills.Controllers;
using MarathonSkillsLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Views.DonatorPages
{
    /// <summary>
    /// Логика взаимодействия для DonationPage.xaml
    /// </summary>
    public partial class DonationPage : Page
    {
        readonly DonationsController donateObj = new DonationsController();
        readonly RunnersController runObj = new RunnersController();
        readonly StringCheckClass strObj = new StringCheckClass();
        /// <summary>
        /// Инициализация элементов страницы DonationPage
        /// </summary>
        public DonationPage()
        {
            InitializeComponent();
            AmountTextBox.Text = "50";
            RunnerComboBox.ItemsSource = runObj.GetRunners();
            RunnerComboBox.SelectedValuePath = "runner_id";
            RunnerComboBox.DisplayMemberPath = "users.UserFullName";
            RunnerComboBox.SelectedValue = 1;

        }

        /// <summary>
        /// Нажатие на кнопку отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Действие на изменение значения AmountTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int amountInt))
            {
                AmountLabel.Content = "$" + AmountTextBox.Text;
            }
            else
            {
                AmountTextBox.Text = "50";
                MessageBox.Show("Была введена неверная сумма пожертвования!");
            }
        }

        /// <summary>
        /// Нажатие на кнопку уменьшения значения AmountTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecreaseAmountButton_Click(object sender, RoutedEventArgs e)
        {
            AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) - 1).ToString();
        }
        /// <summary>
        /// Нажатие на кнопку увеличения значения AmountTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncreaseAmountButton_Click(object sender, RoutedEventArgs e)
        {
            AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) + 1).ToString();
        }

        /// <summary>
        /// Нажатие на кнопку оплатить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            AddingDonation();
        }

        /// <summary>
        /// Произведение оплаты пожертвования
        /// </summary>
        private void AddingDonation()
        {
            string error = SetBorders();
            if (error == String.Empty)
            {
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string otherName = OtherNameTextBox.Text;

                int amount = Convert.ToInt32(AmountTextBox.Text);

                int runnerId = Convert.ToInt32(RunnerComboBox.SelectedValue);

                try
                {
                    donateObj.AddNewDonation(amount, firstName, lastName, otherName, runnerId);
                    MessageBox.Show("Отправка пожертвования произошла успешно!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show(error);
            }
        }

        /// <summary>
        /// Обновление границ заполняемых полей
        /// </summary>
        /// <returns>
        /// Информация о незаполненых полях
        /// </returns>
        private string SetBorders()
        {
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(1);
            CardNameTextBox.BorderBrush = Brushes.Black;
            CardNameTextBox.BorderThickness = new Thickness(1);
            CardNumberTextBox.BorderBrush = Brushes.Black;
            CardNumberTextBox.BorderThickness = new Thickness(1);
            CardMonthTextBox.BorderBrush = Brushes.Black;
            CardMonthTextBox.BorderThickness = new Thickness(1);
            CardYearTextBox.BorderBrush = Brushes.Black;
            CardYearTextBox.BorderThickness = new Thickness(1);
            CvcTextBox.BorderBrush = Brushes.Black;
            CvcTextBox.BorderThickness = new Thickness(1);
            AmountTextBox.BorderBrush = Brushes.Black;
            AmountTextBox.BorderThickness = new Thickness(1);

            string errorString = String.Empty;
            if (String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                || !strObj.NameCheck(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = Brushes.Red;
                FirstNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(LastNameTextBox.Text)
                || !strObj.NameCheck(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = Brushes.Red;
                LastNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(OtherNameTextBox.Text)
                || !strObj.NameCheck(OtherNameTextBox.Text))
            {
                OtherNameTextBox.BorderBrush = Brushes.Red;
                OtherNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Отчества\n";
            }
            if (String.IsNullOrWhiteSpace(CardNameTextBox.Text)
                || !strObj.NameCheck(CardNameTextBox.Text))
            {
                CardNameTextBox.BorderBrush = Brushes.Red;
                CardNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания данных карты\n";
            }
            if (String.IsNullOrWhiteSpace(CardNumberTextBox.Text)
                || !strObj.CardNumberCheck(CardNumberTextBox.Text))
            {
                CardNumberTextBox.BorderBrush = Brushes.Red;
                CardNumberTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания номера карты\n";
            }
            if (String.IsNullOrWhiteSpace(CardMonthTextBox.Text)
                || !strObj.CardMonthCheck(CardMonthTextBox.Text))
            {
                CardMonthTextBox.BorderBrush = Brushes.Red;
                CardMonthTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания номера карты\n";
            }
            if (String.IsNullOrWhiteSpace(CardYearTextBox.Text)
                || !strObj.CardYearCheck(Convert.ToInt32(CardYearTextBox.Text)))
            {
                CardYearTextBox.BorderBrush = Brushes.Red;
                CardYearTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания номера карты\n";
            }
            if (String.IsNullOrWhiteSpace(CvcTextBox.Text)
                || !strObj.CvcCheck(Convert.ToInt32(CvcTextBox.Text)))
            {
                CvcTextBox.BorderBrush = Brushes.Red;
                CvcTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Отчества\n";
            }


            return errorString;
        }

        /// <summary>
        /// Действие на изменение RunnerComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunnerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentRunner = runObj.GetRunnerInfo(Convert.ToInt32(RunnerComboBox.SelectedValue));
            CharityNameTextBlock.Text = currentRunner.charities.charity_name;
            InfoBorder.Visibility = Visibility.Visible;
            if (currentRunner.charities.charity_logo != null)
            {
                ChariryLogoImage.Source = FileManagerClass.GetBytePhotoToImage(currentRunner.charities.charity_logo);
            }
            CharityNameLabel.Content = currentRunner.charities.charity_name;
            CharityDescriptionTextBlock.Text = currentRunner.charities.charity_description;
            InfoBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Нажатие на кнопку назад в окне информации о благотворительной организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Нажатие на кнопку получения информации о благотворительной организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreInfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoBorder.Visibility = Visibility.Visible;
        }
    }
}
