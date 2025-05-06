using System;
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

namespace lab5_task3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] matrix;
        private int matrixSize = 10;
        private int largestPlusSize = 0;
        private int centerRow = 0;
        private int centerCol = 0;

        private readonly SolidColorBrush regularCellBrush = new SolidColorBrush(Colors.LightGray);
        private readonly SolidColorBrush highlightBrush = new SolidColorBrush(Colors.Green);
        private readonly SolidColorBrush oneBrush = new SolidColorBrush(Colors.Black);
        private readonly SolidColorBrush zeroBrush = new SolidColorBrush(Colors.White);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrixSize = int.Parse(txtMatrixSize.Text);
                if (matrixSize < 3 || matrixSize > 30)
                {
                    MessageBox.Show("Please enter a matrix size between 3 and 30.", "Invalid Size", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                GenerateRandomMatrix(matrixSize);
                DisplayMatrix(gridOriginalMatrix, matrix, false);
                ClearResults();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the matrix size.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFindLargestPlus_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Please generate a matrix first.", "No Matrix", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FindLargestPlus();
            DisplayResults();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            matrix = null;
            gridOriginalMatrix.Children.Clear();
            gridOriginalMatrix.RowDefinitions.Clear();
            gridOriginalMatrix.ColumnDefinitions.Clear();
            ClearResults();
        }

        private void ClearResults()
        {
            gridResultMatrix.Children.Clear();
            gridResultMatrix.RowDefinitions.Clear();
            gridResultMatrix.ColumnDefinitions.Clear();
            txtLargestSize.Text = "0";
            txtCenterPosition.Text = "(0,0)";
            txtDebug.Text = string.Empty;
            largestPlusSize = 0;
            centerRow = 0;
            centerCol = 0;
        }

        private void GenerateRandomMatrix(int size)
        {
            matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(2);
                }
            }
        }

        private void FindLargestPlus()
        {
            int n = matrix.GetLength(0);
            StringBuilder debugInfo = new StringBuilder();

            int[,] left = new int[n, n];
            int[,] right = new int[n, n];
            int[,] top = new int[n, n];
            int[,] bottom = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        left[i, j] = matrix[i, j];
                    }
                    else
                    {
                        left[i, j] = matrix[i, j] == 1 ? left[i, j - 1] + 1 : 0;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (j == n - 1)
                    {
                        right[i, j] = matrix[i, j];
                    }
                    else
                    {
                        right[i, j] = matrix[i, j] == 1 ? right[i, j + 1] + 1 : 0;
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        top[i, j] = matrix[i, j];
                    }
                    else
                    {
                        top[i, j] = matrix[i, j] == 1 ? top[i - 1, j] + 1 : 0;
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if (i == n - 1)
                    {
                        bottom[i, j] = matrix[i, j];
                    }
                    else
                    {
                        bottom[i, j] = matrix[i, j] == 1 ? bottom[i + 1, j] + 1 : 0;
                    }
                }
            }

            largestPlusSize = 0;
            centerRow = 0;
            centerCol = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        int currentSize = Math.Min(Math.Min(left[i, j], right[i, j]), Math.Min(top[i, j], bottom[i, j]));

                        int totalPlusSize = currentSize * 4 - 3;

                        if (currentSize > 0 && totalPlusSize > largestPlusSize)
                        {
                            largestPlusSize = totalPlusSize;
                            centerRow = i;
                            centerCol = j;
                        }
                    }
                }
            }

            debugInfo.AppendLine($"Matrix size: {n}x{n}");
            debugInfo.AppendLine($"Largest plus size: {largestPlusSize} units");
            debugInfo.AppendLine($"Center position: ({centerRow},{centerCol})");

            int armLength = (largestPlusSize + 3) / 4;
            debugInfo.AppendLine($"Arm length: {armLength} units");

            txtDebug.Text = debugInfo.ToString();
        }

        private void DisplayResults()
        {
            txtLargestSize.Text = largestPlusSize.ToString();
            txtCenterPosition.Text = $"({centerRow},{centerCol})";
            DisplayMatrix(gridResultMatrix, matrix, true);
        }

        private void DisplayMatrix(Grid grid, int[,] matrixToDisplay, bool highlightPlus)
        {
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            int n = matrixToDisplay.GetLength(0);
            int cellSize = 600 / Math.Max(n, 15);
            for (int i = 0; i < n; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(cellSize) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(cellSize) });
            }

            int armLength = largestPlusSize > 0 ? (largestPlusSize + 3) / 4 : 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Border border = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(0.5),
                    };

                    TextBlock txt = new TextBlock
                    {
                        Text = matrixToDisplay[i, j].ToString(),
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    if (matrixToDisplay[i, j] == 1)
                    {
                        border.Background = oneBrush;
                        txt.Foreground = Brushes.White;
                    }
                    else
                    {
                        border.Background = zeroBrush;
                        txt.Foreground = Brushes.Black;
                    }

                    if (highlightPlus && largestPlusSize > 0 && matrixToDisplay[i, j] == 1)
                    {
                        bool isPartOfPlus = false;

                        if (i == centerRow && j >= centerCol - (armLength - 1) && j <= centerCol + (armLength - 1))
                        {
                            isPartOfPlus = true;
                        }
                        else if (j == centerCol && i >= centerRow - (armLength - 1) && i <= centerRow + (armLength - 1))
                        {
                            isPartOfPlus = true;
                        }

                        if (isPartOfPlus)
                        {
                            border.Background = highlightBrush;
                        }
                    }

                    border.Child = txt;
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    grid.Children.Add(border);
                }
            }
        }
    }
}
