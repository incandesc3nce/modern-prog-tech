using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab5_task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MinWordLength = 6;
        private const int MaxSimilarPairsToDisplay = 20;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            string inputText = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter text in the input field.", "Empty Input",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get all words (alphanumeric sequences)
            string[] allWords = Regex.Split(inputText, @"\s+")
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.Trim())
                .ToArray();

            txtWordCount.Text = allWords.Length.ToString();

            // Filter out words shorter than MinWordLength
            string[] filteredWords = allWords
                .Where(w => w.Length >= MinWordLength)
                .Select(w => w.ToLower()) // Convert to lowercase for case-insensitive comparison
                .Distinct() // Remove duplicates
                .ToArray();

            txtFilteredWordCount.Text = filteredWords.Length.ToString();

            if (filteredWords.Length < 2)
            {
                MessageBox.Show($"Not enough words with at least {MinWordLength} characters found. Please add more text.",
                    "Insufficient Words", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (allWords.Length < 30)
            {
                MessageBox.Show("The text should contain at least 30 words. Please add more text.",
                    "Insufficient Words", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Calculate Levenshtein distances between all word pairs
            txtTransformed.Text = string.Join(" ", filteredWords);

            CalculateDistancesAndDisplayResults(filteredWords);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            lstSimilarPairs.Items.Clear();
            gridDistances.ItemsSource = null;
            txtWordCount.Text = "0";
            txtFilteredWordCount.Text = "0";
            txtTransformed.Clear();
        }

        private void CalculateDistancesAndDisplayResults(string[] words)
        {
            int wordCount = words.Length;
            int[,] distances = new int[wordCount, wordCount];

            // Calculate distances between all word pairs
            for (int i = 0; i < wordCount; i++)
            {
                for (int j = i; j < wordCount; j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = 0; // A word has zero distance to itself
                    }
                    else
                    {
                        int distance = CalculateLevenshteinDistance(words[i], words[j]);
                        distances[i, j] = distance;
                        distances[j, i] = distance; // Distance matrix is symmetric
                    }
                }
            }

            // Create list of word pairs with their distances
            List<WordPair> wordPairs = new List<WordPair>();

            // Track used words to ensure no word appears twice in the output
            HashSet<string> usedWords = new HashSet<string>();

            for (int i = 0; i < wordCount; i++)
            {
                for (int j = i + 1; j < wordCount; j++)
                {
                    wordPairs.Add(new WordPair(
                        words[i],
                        words[j],
                        distances[i, j]
                    ));
                }
            }

            // Sort word pairs by distance (ascending)
            var sortedPairs = wordPairs.OrderBy(pair => pair.Distance).ToList();

            // Display the closest pairs in the ListBox (ensuring no word is used twice)
            lstSimilarPairs.Items.Clear();
            int pairsAdded = 0;

            foreach (var pair in sortedPairs)
            {
                if (pairsAdded >= MaxSimilarPairsToDisplay)
                    break;

                // For each pair, check if we can add it (if both words haven't been used before)
                if (!usedWords.Contains(pair.Word1) && !usedWords.Contains(pair.Word2))
                {
                    lstSimilarPairs.Items.Add($"{pair.Word1} {pair.Word2} (Distance: {pair.Distance})");
                    usedWords.Add(pair.Word1);
                    usedWords.Add(pair.Word2);
                    pairsAdded++;
                }
                // If we've gone through all pairs but don't have enough results,
                // allow one word to appear in multiple pairs
                else if (pairsAdded < MaxSimilarPairsToDisplay &&
                        (!usedWords.Contains(pair.Word1) || !usedWords.Contains(pair.Word2)))
                {
                    lstSimilarPairs.Items.Add($"{pair.Word1} {pair.Word2} (Distance: {pair.Distance})");
                    usedWords.Add(pair.Word1);
                    usedWords.Add(pair.Word2);
                    pairsAdded++;
                }
            }

            // Display distance matrix
            DisplayDistanceMatrix(words, distances);
        }

        private int CalculateLevenshteinDistance(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;
            int[,] d = new int[m + 1, n + 1];

            // Step 1: Initialize
            for (int i = 0; i <= m; i++)
                d[i, 0] = i;

            for (int j = 0; j <= n; j++)
                d[0, j] = j;

            // Step 2: Fill the matrix
            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[m, n];
        }

        private void DisplayDistanceMatrix(string[] words, int[,] distances)
        {
            // Create DataTable for the distance matrix
            DataTable table = new DataTable();

            // Add a column for word labels
            table.Columns.Add("Words", typeof(string));

            // Add a column for each word
            for (int i = 0; i < words.Length; i++)
            {
                table.Columns.Add(words[i], typeof(int));
            }

            // Fill rows with distance values
            for (int i = 0; i < words.Length; i++)
            {
                DataRow row = table.NewRow();
                row[0] = words[i];

                for (int j = 0; j < words.Length; j++)
                {
                    row[j + 1] = distances[i, j];
                }

                table.Rows.Add(row);
            }

            // Set DataGrid's ItemSource
            gridDistances.ItemsSource = table.DefaultView;
        }

        private class WordPair
        {
            public string Word1 { get; }
            public string Word2 { get; }
            public int Distance { get; }

            public WordPair(string word1, string word2, int distance)
            {
                Word1 = word1;
                Word2 = word2;
                Distance = distance;
            }
        }
    }
}
