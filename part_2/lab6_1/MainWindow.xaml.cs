using System;
using System.Collections.Generic;
using System.Linq;
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

namespace lab6_1
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

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstResults.Items.Clear();

                                if (!int.TryParse(txtN.Text, out int n) || n < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative integer for N.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                                List<string> elements = txtElements.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (elements.Count == 0)
                {
                    MessageBox.Show("Please enter at least one element.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                                List<string> results = new List<string>();

                if (rbSubsets.IsChecked == true)
                {
                                        GenerateSubsets(elements, results);
                }
                else if (rbPermutations.IsChecked == true)
                {
                                        GeneratePermutations(elements, results);
                }
                else if (rbCombinations.IsChecked == true)
                {
                                        if (!int.TryParse(txtM.Text, out int m) || m < 0 || m > n)
                    {
                        MessageBox.Show("Please enter a valid M (0 ≤ M ≤ N).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    GenerateCombinations(elements, m, results);
                }
                else if (rbArrangements.IsChecked == true)
                {
                                        if (!int.TryParse(txtM.Text, out int m) || m < 0 || m > n)
                    {
                        MessageBox.Show("Please enter a valid M (0 ≤ M ≤ N).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    GenerateArrangements(elements, m, results);
                }
                else if (rbPermWithRep.IsChecked == true)
                {
                                        List<int> repetitionCounts = new List<int>();
                    if (!string.IsNullOrEmpty(txtRepetitionCounts.Text))
                    {
                        try
                        {
                            repetitionCounts = txtRepetitionCounts.Text
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

                            if (repetitionCounts.Count != elements.Count)
                            {
                                MessageBox.Show("The number of repetition counts must match the number of elements.",
                                    "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Please enter valid integers for repetition counts.",
                                "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                                                repetitionCounts = Enumerable.Repeat(1, elements.Count).ToList();
                    }

                    GeneratePermutationsWithRepetition(elements, repetitionCounts, results);
                }
                else if (rbCombWithRep.IsChecked == true)
                {
                                        if (!int.TryParse(txtM.Text, out int m) || m < 0)
                    {
                        MessageBox.Show("Please enter a valid non-negative integer for M.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    GenerateCombinationsWithRepetition(elements, m, results);
                }

                                foreach (var result in results)
                {
                    lstResults.Items.Add(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();
        }

        #region Combinatorial Algorithms

        private void GenerateSubsets(List<string> elements, List<string> results)
        {
            int n = elements.Count;
            int totalSubsets = 1 << n;

            for (int i = 0; i < totalSubsets; i++)
            {
                List<string> subset = new List<string>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(elements[j]);
                    }
                }
                results.Add(subset.Count > 0 ? string.Join(" ", subset) : "∅");
            }
        }

        private void GeneratePermutations(List<string> elements, List<string> results)
        {
            GeneratePermutationsHelper(elements.ToArray(), 0, elements.Count - 1, results);
        }

        private void GeneratePermutationsHelper(string[] elements, int start, int end, List<string> results)
        {
            if (start == end)
            {
                results.Add(string.Join(" ", elements));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref elements[start], ref elements[i]);
                    GeneratePermutationsHelper(elements, start + 1, end, results);
                    Swap(ref elements[start], ref elements[i]); // backtrack
                }
            }
        }

        private void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        private void GenerateCombinations(List<string> elements, int m, List<string> results)
        {
            bool[] selected = new bool[elements.Count];
            GenerateCombinationsHelper(elements, selected, 0, m, results);
        }

        private void GenerateCombinationsHelper(List<string> elements, bool[] selected, int start, int m, List<string> results)
        {
            if (m == 0)
            {
                List<string> combination = new List<string>();
                for (int i = 0; i < selected.Length; i++)
                {
                    if (selected[i])
                    {
                        combination.Add(elements[i]);
                    }
                }
                results.Add(string.Join(" ", combination));
                return;
            }

            if (start == elements.Count)
            {
                return;
            }

            selected[start] = true;
            GenerateCombinationsHelper(elements, selected, start + 1, m - 1, results);

            selected[start] = false;
            GenerateCombinationsHelper(elements, selected, start + 1, m, results);
        }

        private void GenerateArrangements(List<string> elements, int m, List<string> results)
        {
            List<string> current = new List<string>();
            bool[] used = new bool[elements.Count];
            GenerateArrangementsHelper(elements, m, current, used, results);
        }

        private void GenerateArrangementsHelper(List<string> elements, int m, List<string> current, bool[] used, List<string> results)
        {
            if (current.Count == m)
            {
                results.Add(string.Join(" ", current));
                return;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    current.Add(elements[i]);
                    GenerateArrangementsHelper(elements, m, current, used, results);
                    current.RemoveAt(current.Count - 1);
                    used[i] = false;
                }
            }
        }

        private void GeneratePermutationsWithRepetition(List<string> elements, List<int> repetitionCounts, List<string> results)
        {
            int totalLength = repetitionCounts.Sum();
            string[] current = new string[totalLength];
            GeneratePermutationsWithRepetitionHelper(elements, repetitionCounts, current, 0, results);
        }

        private void GeneratePermutationsWithRepetitionHelper(List<string> elements, List<int> repetitionCounts, string[] current, int position, List<string> results)
        {
            if (position == current.Length)
            {
                results.Add(string.Join(" ", current));
                return;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (repetitionCounts[i] > 0)
                {
                    current[position] = elements[i];
                    repetitionCounts[i]--;

                    GeneratePermutationsWithRepetitionHelper(elements, repetitionCounts, current, position + 1, results);

                    repetitionCounts[i]++;
                }
            }
        }

        private void GenerateCombinationsWithRepetition(List<string> elements, int m, List<string> results)
        {
            List<string> current = new List<string>();
            GenerateCombinationsWithRepetitionHelper(elements, m, 0, current, results);
        }

        private void GenerateCombinationsWithRepetitionHelper(List<string> elements, int m, int start, List<string> current, List<string> results)
        {
            if (current.Count == m)
            {
                results.Add(string.Join(" ", current));
                return;
            }

            for (int i = start; i < elements.Count; i++)
            {
                current.Add(elements[i]);
                GenerateCombinationsWithRepetitionHelper(elements, m, i, current, results);
                current.RemoveAt(current.Count - 1);
            }
        }

        #endregion
    }
}
