using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab5_task3_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> numbers = new List<int>();
        private List<int>[] subsets = new List<int>[3];
        private int targetSum;
        private int recursiveCalls = 0;
        private StringBuilder logBuilder = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize subsets
            for (int i = 0; i < 3; i++)
            {
                subsets[i] = new List<int>();
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear previous results
                ClearResults();

                // Parse input
                string input = txtInput.Text.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("Введите числа разделенные пробелом.");
                    return;
                }

                numbers = input.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s.Trim()))
                    .ToList();

                if (numbers.Count == 0)
                {
                    ShowError("Чисел нет.");
                    return;
                }

                if (numbers.Any(n => n <= 0))
                {
                    ShowError("Все числа должны быть положительными.");
                    return;
                }

                // Calculate the total sum
                int totalSum = numbers.Sum();

                // Check if the sum is divisible by 3
                if (totalSum % 3 != 0)
                {
                    txtResult.Text = "Решения нет";
                    txtSumInfo.Text = $"Полная сумма: {totalSum} (не делится на 3)";
                    LogMessage($"Полная сумма {totalSum} не делится на 3, поэтому решения нет.");
                    return;
                }

                targetSum = totalSum / 3;
                txtSumInfo.Text = $"Полная сумма: {totalSum}, Сумма на каждое подмножество: {targetSum}";

                LogMessage($"Начинаем поиск со следующими числами: {string.Join(", ", numbers)}");
                LogMessage($"Необходимая сумма на каждое подмножество: {targetSum}");

                // Start timer
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Sort numbers in descending order for optimization
                numbers.Sort((a, b) => b.CompareTo(a));

                // Try to find a partition
                bool found = CanPartition();

                // Stop timer
                stopwatch.Stop();

                if (found)
                {
                    txtResult.Text = "Решение найдено!";
                    DisplaySubsets();
                }
                else
                {
                    txtResult.Text = "Решения нет, числа нельзя разделить на 3 подмножества";
                }

                // Display performance metrics
                txtTime.Text = $"{stopwatch.ElapsedMilliseconds} ms";
                txtCalls.Text = recursiveCalls.ToString();

                LogMessage($"Поиск занял {stopwatch.ElapsedMilliseconds} мс");
            }
            catch (FormatException)
            {
                ShowError("Неверный ввод.");
            }
            catch (Exception ex)
            {
                ShowError($"Произошла ошибка: {ex.Message}");
            }
        }

        private bool CanPartition()
        {
            // Reset for fresh calculation
            recursiveCalls = 0;
            for (int i = 0; i < 3; i++)
            {
                subsets[i].Clear();
            }

            return TryPartition(0, new int[3]);
        }

        private bool TryPartition(int index, int[] sums)
        {
            recursiveCalls++;

            // Base case: all numbers have been assigned
            if (index == numbers.Count)
            {
                // Check if all sums are equal
                return sums[0] == sums[1] && sums[1] == sums[2];
            }

            int currentNum = numbers[index];
            LogMessage($"Подставляем {currentNum} (индекс {index})");

            // Try adding the current number to each subset
            for (int i = 0; i < 3; i++)
            {
                // Skip if adding this number would exceed the target sum
                if (sums[i] + currentNum > targetSum)
                {
                    LogMessage($"  Пропускаем подмножество {i + 1}: {sums[i]} + {currentNum} > {targetSum}");
                    continue;
                }

                LogMessage($"  Добавляем {currentNum} к подмножеству {i + 1} (текущая сумма: {sums[i]})");

                // Add number to this subset
                subsets[i].Add(currentNum);
                sums[i] += currentNum;

                // Recursively try to place the rest of the numbers
                if (TryPartition(index + 1, sums))
                {
                    return true;
                }

                // Backtrack
                subsets[i].Remove(currentNum);
                sums[i] -= currentNum;
                LogMessage($"  Убираем {currentNum} из подмножества {i + 1} (возврат)");

                // Optimization: if this is the first position in subset, there's no need to try other empty subsets
                if (sums[i] == 0)
                {
                    break;
                }
            }

            return false;
        }

        private void DisplaySubsets()
        {
            // Display subset contents
            txtSubset1.Text = string.Join(", ", subsets[0]);
            txtSubset2.Text = string.Join(", ", subsets[1]);
            txtSubset3.Text = string.Join(", ", subsets[2]);

            // Display sums
            txtSum1.Text = $"Сумма: {subsets[0].Sum()}";
            txtSum2.Text = $"Сумма: {subsets[1].Sum()}";
            txtSum3.Text = $"Сумма: {subsets[2].Sum()}";
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void LogMessage(string message)
        {
            logBuilder.AppendLine(message);
            txtLog.Text = logBuilder.ToString();
            txtLog.ScrollToEnd();
        }

        private void ClearResults()
        {
            // Clear subsets
            for (int i = 0; i < 3; i++)
            {
                subsets[i].Clear();
            }

            // Clear UI elements
            txtResult.Text = "";
            txtSumInfo.Text = string.Empty;
            txtSubset1.Text = string.Empty;
            txtSubset2.Text = string.Empty;
            txtSubset3.Text = string.Empty;
            txtSum1.Text = string.Empty;
            txtSum2.Text = string.Empty;
            txtSum3.Text = string.Empty;
            txtTime.Text = "0 ms";
            txtCalls.Text = "0";

            // Clear log
            logBuilder.Clear();
            txtLog.Text = string.Empty;

            // Reset counters
            recursiveCalls = 0;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            ClearResults();
        }
    }
}
