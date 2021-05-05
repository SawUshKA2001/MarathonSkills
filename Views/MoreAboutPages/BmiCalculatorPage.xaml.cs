using MarathonSkillsLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Views.MoreAboutPages
{
    /// <summary>
    /// Логика взаимодействия для BmiCalculatorPage.xaml
    /// </summary>
    public partial class BmiCalculatorPage : Page
    {
        /// <summary>
        /// Инициализация элементов страницы BmiCalculatorPage
        /// </summary>
        public BmiCalculatorPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку посчитать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            string errors = SetBorders();
            if (errors == String.Empty)
            {
                double bmi = BmiCalculatorClass.CalculateBmi(Convert.ToInt32(WeightTextBox.Text), Convert.ToInt32(HeightTextBox.Text));
                BmiValueTextBlock.Text = "Ваш индекс массы тела: " + bmi.ToString();
                BmiResultTextBlock.Text = "Ваш результат: " + BmiCalculatorClass.GetBmiCategory(bmi);
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        /// <summary>
        /// Обновление границ заполняемых полей
        /// </summary>
        /// <returns>
        /// Информация о незаполненных полях
        /// </returns>
        private string SetBorders()
        {
            string errorsString = String.Empty;

            WeightTextBox.BorderBrush = Brushes.Black;
            WeightTextBox.BorderThickness = new Thickness(1);
            HeightTextBox.BorderBrush = Brushes.Black;
            HeightTextBox.BorderThickness = new Thickness(1);


            if (!int.TryParse(HeightTextBox.Text, out int num) || String.IsNullOrWhiteSpace(HeightTextBox.Text))
            {
                HeightTextBox.BorderBrush = Brushes.Red;
                HeightTextBox.BorderThickness = new Thickness(3);
                errorsString += "Значением роста должно быть целое число!\n";
            }
            if (!int.TryParse(WeightTextBox.Text, out num) || String.IsNullOrWhiteSpace(WeightTextBox.Text))
            {
                WeightTextBox.BorderBrush = Brushes.Red;
                WeightTextBox.BorderThickness = new Thickness(3);
                errorsString += "Значением веса должно быть целое число!\n";
            }
            return errorsString;
        }
    }
}
