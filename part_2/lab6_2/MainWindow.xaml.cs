using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace lab6_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();
            txtMaxProduct.Text = "";

            // Получаем числа и K
            var numbersStr = txtNumbers.Text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(txtK.Text, out int k) || k <= 0)
            {
                MessageBox.Show("Введите корректное значение K.");
                return;
            }
            var numbers = new List<int>();
            foreach (var s in numbersStr)
            {
                if (int.TryParse(s, out int num))
                    numbers.Add(num);
                else
                {
                    MessageBox.Show("Введите только целые числа через пробел.");
                    return;
                }
            }
            if (k > numbers.Count)
            {
                MessageBox.Show("K не может быть больше количества чисел.");
                return;
            }

            // Генерируем все сочетания
            var allCombs = new List<List<int>>();
            GenerateCombinations(numbers, k, 0, new List<int>(), allCombs);

            // Находим максимальное произведение
            int maxProduct = int.MinValue;
            List<int> maxComb = null;
            foreach (var comb in allCombs)
            {
                int prod = comb.Aggregate(1, (a, b) => a * b);
                lstResults.Items.Add($"{string.Join(" ", comb)} = {prod}");
                if (prod > maxProduct)
                {
                    maxProduct = prod;
                    maxComb = new List<int>(comb);
                }
            }

            if (maxComb != null)
                txtMaxProduct.Text = $"Максимальное произведение: {maxProduct} ({string.Join(" ", maxComb)})";
        }

        // Рекурсивная генерация сочетаний
        private void GenerateCombinations(List<int> numbers, int k, int start, List<int> current, List<List<int>> result)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }
            for (int i = start; i < numbers.Count; i++)
            {
                current.Add(numbers[i]);
                GenerateCombinations(numbers, k, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
