using System;
using System.Windows;
using alg1wpf.logical;
using alg1wpf.view;

namespace alg1wpf
{
    public enum Lab { first, second }
    public enum Algoritms { first, second }
    public enum Experiment { first, second }
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

        Lab lab = Lab.first;
        Algoritms algoritms = Algoritms.first;
        Experiment experiment = Experiment.first;
        

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            Algoritms algoritms = Algoritms.first;
            Experiment experiment = Experiment.first;
            if (lab == Lab.first)
            {
                switch (SelectAlgoritm2.Text)
                {
                    case "Алгоритм Дейкстры на основе 7-кучи":
                        {
                            algoritms = Algoritms.first;
                            break;
                        }
                    case "Алгоритм Форда-Беллмана":
                        {
                            algoritms = Algoritms.second;
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
            else
            {
                switch (SelectAlgoritm3.Text)
                {
                    case "Алгоритм Борувки":
                        {
                            algoritms = Algoritms.first;
                            break;
                        }
                    case "Алгоритм Краскала":
                        {
                            algoritms = Algoritms.second;
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
            
            switch (SelectExperiment.Text)
            {
                case "1":
                    {
                        experiment = Experiment.first;
                        break;
                    }
                case "2":
                    {
                        experiment = Experiment.second;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            Graph graph;
            if (lab == Lab.first)
            {
                graph = new GraphForSecondLab();
            }
            else
            {
                graph = new GraphForThirdLab();
            }

            if (algoritms == Algoritms.first)
            {
                if (experiment == Experiment.first)
                {
                    LineModel.ItemsSource = new PointModel(graph.FirstExperimentForFirstMethod(), 100000, 100000).Points;
                    LineModel.Visibility = Visibility.Visible;
                }
                else
                {
                    LineModel.ItemsSource = new PointModel(graph.SecondExperimentForFirstMethod(), 100000, 100000).Points;
                    LineModel.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (experiment == Experiment.first)
                {
                    LineModel.ItemsSource = new PointModel(graph.FirstExperimentForSecondMethod(), 100000, 100000).Points;
                    LineModel.Visibility = Visibility.Visible;
                }
                else
                {
                    LineModel.ItemsSource = new PointModel(graph.SecondExperimentForSecondMethod(), 100000, 100000).Points;
                    LineModel.Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SelectLab_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectLab.Text == "")
            {
                return;
            }
            TitleAlgoritm.Visibility = Visibility.Visible;
            if (SelectLab.Text == "2, кратчайшие пути")
            {
                SelectAlgoritm2.Visibility = Visibility.Visible;
                SelectAlgoritm3.Visibility = Visibility.Hidden;
                lab = Lab.first;
            }
            else
            {
                SelectAlgoritm2.Visibility = Visibility.Hidden;
                SelectAlgoritm3.Visibility = Visibility.Visible;
                lab = Lab.second;
            }
            TitleExperiment.Visibility = Visibility.Hidden;
            SelectExperiment.Visibility = Visibility.Hidden;
        }

        private void SelectAlgoritm_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectAlgoritm2.Visibility == Visibility.Visible && SelectAlgoritm2.Text == "")
                return;
            if (SelectAlgoritm3.Visibility == Visibility.Visible && SelectAlgoritm3.Text == "")
                return;
            
            TitleExperiment.Visibility = Visibility.Visible;
            SelectExperiment.Visibility = Visibility.Visible;
        }

        private void SelectExperiment_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectExperiment.Text == "")
            {
                return;
            }
            ButtonResult.IsEnabled = true;
        }
    }
}
