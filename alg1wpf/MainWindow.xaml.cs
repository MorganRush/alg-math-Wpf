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

namespace alg1wpf
{
    public enum Algoritms { DijkstraDHeap, FordBellman }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window.Width = 850;
            Window.Height = 450;
            return;
        }

        private void SelectAlgoritm_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectAlgoritm.Text == "")
            {
                return;
            }
            SelectExperiment.Visibility = Visibility.Visible;
            TitleExperiment.Visibility = Visibility.Visible;
        }

        private void SelectExperiment_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectAlgoritm.Text == "")
            {
                return;
            }
            ButtonResult.IsEnabled = true;
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            switch (SelectAlgoritm.Text)
            {
                case "Алгоритм Дейкстры на основе 7-кучи":
                    {
                        break;
                    }
                case "Алгоритм Форда-Беллмана":
                    {
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
