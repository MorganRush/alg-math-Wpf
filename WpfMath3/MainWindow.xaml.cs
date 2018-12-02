using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfMath3.View;
using WpfMath3.Logical;

namespace WpfMath3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countPoints;
        private List<TextBox> inputPoint = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectFunction.Text == "")
                {
                    MessageBox.Show("Пожалуйста, выберите функцию");
                    return;
                }
                if (SelectCountPoint.Text == "")
                {
                    MessageBox.Show("Пожалуйста ,выберите кол-во точек");
                    return;
                }
                double[] x = new double[countPoints];
                for (int i = 0; i < countPoints; i++)
                {
                    if ((inputPoint[i].Text == "") || (!Double.TryParse(inputPoint[i].Text, out x[i])))
                    {
                        MessageBox.Show("Пожалуйста, проверьте координаты точек");
                        return;
                    }
                }
                Func<double, double> function;
                switch (SelectFunction.Text)
                {
                    case "sin(x)": { function = Math.Sin; break; }
                    case "cos(x)": { function = Math.Cos; break; }
                    case "1": { function = t => 1; break; }
                    case "x": { function = t => t; break; }
                    case "x^2": { function = t => t * t; break; }
                    default: { return; }
                }
                FunctionContent content = new FunctionContent(x, function);
                this.Image.Model = new InterpolationModel(content).model;
                this.Image.Visibility = Visibility.Visible;
            }
            catch(Exception exception)
            {
                this.Image.Visibility = Visibility.Hidden;
                MessageBox.Show(exception.Message);
                return;
            }
        }
        private int SetCountPoints(string text)
        {
            switch (text)
            {
                case "4": { return 4; }
                case "5": { return 5; }
                case "6": { return 6; }
                case "7": { return 7; }
                case "8": { return 8; }
                default: { return 0; }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            inputPoint.Add(x0);
            inputPoint.Add(x1);
            inputPoint.Add(x2);
            inputPoint.Add(x3);
            inputPoint.Add(x4);
            inputPoint.Add(x5);
            inputPoint.Add(x6);
            inputPoint.Add(x7);
            countPoints = 0;
        }
        private void SelectCountPoint_DropDownClosed(object sender, EventArgs e)
        {
            if (SelectCountPoint.Text == "")
                return;
            int newCount = SetCountPoints(SelectCountPoint.Text);
            if (newCount == 0)
                return;
            for (int i = 0; i < newCount; i++)
            {
                inputPoint[i].Text = "";
                inputPoint[i].Visibility = Visibility.Visible;
            }
            for (int i = newCount; i < countPoints; i++)
            {
                inputPoint[i].Text = "";
                inputPoint[i].Visibility = Visibility.Hidden;
            }
            countPoints = newCount;
            text1.Visibility = Visibility.Visible;
            text2.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Hidden;
        }
    }
}
