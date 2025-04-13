using System;
using System.Windows;
using System.Windows.Controls;

namespace programming_Lab4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TriangleSideInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput(TriangleSideInput, out double side))
            {
                TriangleSideInput.Focus();
                return;
            }

            UpdateCalculations();
        }

        private void PrismHeightInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput(PrismHeightInput, out double height))
            {
                PrismHeightInput.Focus();
                return;
            }

            UpdateCalculations();
        }

        private bool ValidateInput(TextBox textBox, out double value)
        {
            if (!double.TryParse(textBox.Text, out value) || value <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Text = string.Empty;
                return false;
            }
            return true;
        }

        private void UpdateCalculations()
        {
            if (double.TryParse(TriangleSideInput.Text, out double side) &&
                double.TryParse(PrismHeightInput.Text, out double height))
            {
                // Вычисление площади поверхности и объема
                double baseArea = (Math.Sqrt(3) / 4) * Math.Pow(side, 2); // Площадь основания
                double lateralArea = 3 * side * height; // Площадь боковой поверхности
                double surfaceArea = 2 * baseArea + lateralArea; // Полная площадь поверхности
                double volume = baseArea * height; // Объем

                // Вывод результатов
                SurfaceAreaOutput.Content = surfaceArea.ToString("F2");
                VolumeOutput.Content = volume.ToString("F2");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}