using System;
using System.Collections.Generic;
using System.Windows;
using Math4Wpf.Logical;
using Math4Wpf.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Math4Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((this.xStart.Text == "") || (this.xEnd.Text == "") || (this.yStart.Text == ""))
                    throw new FunctionException("Пожалуйста, введите начальные условия");
                if (this.Precision.Text == "")
                    throw new FunctionException("Пожалуйста, введите точность");
                if ((!Double.TryParse(this.xStart.Text, out double xStart)) || (!Double.TryParse(this.xEnd.Text, out double xEnd))
                    || (!Double.TryParse(this.yStart.Text, out double yStart)))
                    throw new FunctionException("Пожалуйста, проверьте начальные условия");
                if (!Double.TryParse(this.Precision.Text, out double precision))
                    throw new FunctionException("Пожалуйста, проверьте точность");
                if (xEnd < xStart)
                    throw new FunctionException("Начальное значение x дб больше конечного");
                Func<double, double, double> function;
                if (precision > 1)
                    throw new FunctionException("Выберите меньшую точность");
                switch(SelectFunction.Text)
                {
                    case "y' = x^2 - 2y": { function = (x, y) => x*x - 2 * y; break; }
                    case "y' = yx + x^2": { function = (x, y) => x * y + x*x; break; }
                    case "e^x + Sin(x) - sqrt(x)": { function = (x, y) => 
                    Math.Pow(Math.E, x) + Math.Sin(x) - Math.Pow(x, 1/2); break; }
                    default: { throw new FunctionException("Функция задана неверно"); }
                }               
                DifferentialFunctionContent content = new DifferentialFunctionContent(xStart, xEnd, yStart, precision, 5, function);
                this.Line.ItemsSource = new PointModel(content).Points;
                this.Line.Visibility = Visibility.Visible;
                /*
                if (content.X[1] - content.X[0] > 1)
                {
                    this.Graphic.Model = new PointPlotModel(content).model;
                    this.Graphic.Visibility = Visibility.Visible;
                    this.Line.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Line.ItemsSource = new PointModel(content).Points;
                    this.Line.Visibility = Visibility.Visible;
                    this.Graphic.Visibility = Visibility.Hidden;
                }  
                */
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void SelectFunction_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectFunction.Text == "")
                return;
            ButtonResult.IsEnabled = true;
            this.inform1.Visibility = Visibility.Visible;
            this.text1.Visibility = Visibility.Visible;
            this.text2.Visibility = Visibility.Visible;
            this.text3.Visibility = Visibility.Visible;
            this.text4.Visibility = Visibility.Visible;
            this.text5.Visibility = Visibility.Visible;
            this.xStart.Visibility = Visibility.Visible;
            this.xEnd.Visibility = Visibility.Visible;
            this.yStart.Visibility = Visibility.Visible;
            this.Precision.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ButtonResult.IsEnabled = false;
            this.inform1.Visibility = Visibility.Hidden;
            this.Graphic.Visibility = Visibility.Hidden;
            this.Line.Visibility = Visibility.Hidden;
            this.text1.Visibility = Visibility.Hidden;
            this.text2.Visibility = Visibility.Hidden;
            this.text3.Visibility = Visibility.Hidden;
            this.text4.Visibility = Visibility.Hidden;
            this.text5.Visibility = Visibility.Hidden;
            this.xStart.Visibility = Visibility.Hidden;
            this.xEnd.Visibility = Visibility.Hidden;
            this.yStart.Visibility = Visibility.Hidden;
            this.Precision.Visibility = Visibility.Hidden;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.form.Width = 850;
            this.form.Height = 450;
            return;
        }
    }
}
