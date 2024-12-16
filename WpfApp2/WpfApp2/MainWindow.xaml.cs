using System;
using System.Collections.Generic;
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
using System.Threading;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private readonly NumberGeherateYield _numberGeneratorYield;
        public MainWindow()
        {
            InitializeComponent();
            _numberGeneratorYield = new NumberGeherateYield();
        }

        private async void GenerateButtonClick(object sender, RoutedEventArgs e)
        {
            NumbersListBox.Items.Clear();
            ProgressBar.Value = 0;

            if (int.TryParse(StartTextBox.Text, out int start) && int.TryParse(EndTextBox.Text, out int end))
            {
                int totalNumner = end - start + 1;
                ProgressBar.Maximum = totalNumner;

                Thread thread = new Thread(() =>
                {
                    foreach (var number in _numberGeneratorYield.GenerateNumbers(start, end))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            NumbersListBox.Items.Add(number);
                            ProgressBar.Value++;
                        });
                    }
                    Dispatcher.Invoke(() => MessageBox.Show("Генерация завершена!"));
                });
                thread.Start();

            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа.");
            }
        }

    }
}
