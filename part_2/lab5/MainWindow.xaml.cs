using System;
using System.Collections.Generic;
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

namespace lab5
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string word1 = txtWord1.Text;
            string word2 = txtWord2.Text;

            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            {
                MessageBox.Show("Введите два слова", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int[,] matrix = CalculateLevenshteinMatrix(word1, word2);

            txtDistance.Text = matrix[word1.Length, word2.Length].ToString();

            DisplayMatrix(matrix, word1, word2);

            List<string> transformations = GetTransformationSteps(matrix, word1, word2);
            lstTransformations.ItemsSource = transformations;
        }

        private int[,] CalculateLevenshteinMatrix(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;
            int[,] d = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
                d[i, 0] = i;
            for (int j = 0; j <= n; j++)
                d[0, j] = j;
            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d;
        }

        private void DisplayMatrix(int[,] matrix, string word1, string word2)
        {
            gridMatrix.Children.Clear();
            gridMatrix.RowDefinitions.Clear();
            gridMatrix.ColumnDefinitions.Clear();

            int rows = word1.Length + 1;
            int cols = word2.Length + 1;

            for (int i = 0; i < rows + 1; i++)
                gridMatrix.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int j = 0; j < cols + 1; j++)
                gridMatrix.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            AddCell(0, 0, "", Colors.LightGray);

            for (int j = 0; j < word2.Length; j++)
                AddCell(0, j + 2, word2[j].ToString(), Colors.LightGray);

            for (int i = 0; i < word1.Length; i++)
                AddCell(i + 2, 0, word1[i].ToString(), Colors.LightGray);

            AddCell(1, 0, "", Colors.LightGray);
            AddCell(0, 1, "", Colors.LightGray);

            for (int i = 0; i <= word1.Length; i++)
                AddCell(i + 1, 1, i.ToString(), Colors.LightGray);

            for (int j = 0; j <= word2.Length; j++)
                AddCell(1, j + 1, j.ToString(), Colors.LightGray);

            for (int i = 0; i <= word1.Length; i++)
            {
                for (int j = 0; j <= word2.Length; j++)
                {
                    AddCell(i + 1, j + 1, matrix[i, j].ToString(), Colors.White);
                }
            }
        }

        private void AddCell(int row, int col, string text, Color bgColor)
        {
            Border border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Background = new SolidColorBrush(bgColor)
            };

            TextBlock textBlock = new TextBlock
            {
                Text = text,
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = textBlock;
            Grid.SetRow(border, row);
            Grid.SetColumn(border, col);
            gridMatrix.Children.Add(border);
        }

        private List<string> GetTransformationSteps(int[,] matrix, string source, string target)
        {
            List<string> steps = new List<string>();
            int i = source.Length;
            int j = target.Length;

            string currentWord = target;

            while (i > 0 || j > 0)
            {
                if (i > 0 && j > 0 && matrix[i, j] == matrix[i - 1, j - 1] && source[i - 1] == target[j - 1])
                {
                    steps.Add($"Оставить {source[i - 1]}");
                    i--;
                    j--;
                }
                else if (i > 0 && j > 0 && matrix[i, j] == matrix[i - 1, j - 1] + 1)
                {
                    char[] chars = currentWord.ToCharArray();
                    chars[j - 1] = source[i - 1];
                    currentWord = new string(chars);
                    steps.Add($"Заменить {source[i - 1]} на {target[j - 1]}");
                    i--;
                    j--;
                }
                else if (i > 0 && matrix[i, j] == matrix[i - 1, j] + 1)
                {
                    currentWord = currentWord.Insert(j, source[i - 1].ToString());
                    steps.Add($"Удалить {source[i - 1]}");
                    i--;
                }
                else if (j > 0 && matrix[i, j] == matrix[i, j - 1] + 1)
                {
                    currentWord = currentWord.Remove(j - 1, 1);
                    steps.Add($"Вставить {target[j - 1]}");
                    j--;
                }
            }

            steps.Reverse();
            return steps;
        }
    }
}
