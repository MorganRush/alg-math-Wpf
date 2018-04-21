using System;
using System.Windows;
using alg1wpf.logical;
using alg1wpf.view;

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
            int numberExperiment = 0;
            Algoritms algoritms = Algoritms.DijkstraDHeap;
            switch (SelectAlgoritm.Text)
            {
                case "Алгоритм Дейкстры на основе 7-кучи":
                    {
                        algoritms = Algoritms.DijkstraDHeap;
                        break;
                    }
                case "Алгоритм Форда-Беллмана":
                    {
                        algoritms = Algoritms.FordBellman;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            switch (SelectExperiment.Text)
            {
                case "1":
                    {
                        numberExperiment = 1;
                        break;
                    }
                case "2":
                    {
                        numberExperiment = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            Graph graph = new Graph();
            if (algoritms == Algoritms.DijkstraDHeap)
            {
                if (numberExperiment == 1)
                {
                    LineModel.ItemsSource = new PointModel(graph.FirstExperimentForDijkstraDHeap(), 100000, 100000).Points;
                    LineModel.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("1 2");
                }
            } 
            else
            {
                if (numberExperiment == 1)
                {
                    MessageBox.Show("2 1");
                }
                else
                {
                    MessageBox.Show("2 2");
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
