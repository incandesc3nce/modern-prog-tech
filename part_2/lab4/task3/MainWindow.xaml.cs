using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void display(string message, double? value = null)
        {
            ResultLabel.Content = message;
            if (value != null)
            {
                ValueLabel.Content = $"{value:F2}";
            }
        }

        private void calculate(double value, int formula)
        {
            double result = 0;
            switch (formula)
            {
                case 1:
                    result = Math.Pow(Math.Sin(value), 2);
                    break;
                case 2:
                    result = 2 * Math.Pow(value, 3) - 2;
                    break;
                case 3:
                    result = (2 * value + 4) * value;
                    break;
                default:
                    MessageBox.Show("Выберите формулу.");
                    return;
            }
            if (DoubleResultCheckBox.IsChecked == true)
            {
                result *= 2;
            }
            display("Результат:", result);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double x))
            {
                if (x <= 2)
                {
                    calculate(x, 1);
                    Formula1RadioButton.IsChecked = true;
                }
                else if (x > 2 && x < 3)
                {
                    calculate(x, 2);
                    Formula2RadioButton.IsChecked = true;
                }
                else if (x >= 3)
                {
                    calculate(x, 3);
                    Formula3RadioButton.IsChecked = true;
                }
                else
                {
                    display("Введите корректное значение x.");
                }
            }
        }

        private void DoubleResultCheckBox_Checked(object sender, RoutedEventArgs e)
        {   
            var value = ValueLabel.Content.ToString();
            if (double.TryParse(value, out double x))
            {
                double result = x * 2;
                display("Результат:", result);
            }
        }
        private void DoubleResultCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var value = ValueLabel.Content.ToString();
            if (double.TryParse(value, out double x))
            {
                double result = x / 2;
                display("Результат:", result);
            }
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double x))
            {
                calculate(x, 1);
            }
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double x))
            {
                calculate(x, 2);
            }
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double x))
            {
                calculate(x, 3);
            }
        }
    }
}