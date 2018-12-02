using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMath3.LogicalOld
{
    public class FunctionContent
    {
        public FunctionContent(double[] x, Func<double, double> function)
        {
            int size = x.Length;
            this.x = new double[size];
            this.y = new double[size];
            stepX = new double[size - 1];
            stepYdivStepX = new double[size - 1];
            delta = new double[size - 1];
            lambda = new double[size - 1];
            a = new double[size - 1];
            b = new double[size - 1];
            c = new double[size - 1];
            d = new double[size - 1];
            for (int i = 0; i < size; i++)
                this.x[i] = x[i];
            for (int i = 0; i < size; i++)
                this.y[i] = function(x[i]);
            for (int i = 0; i < size - 1; i++)
                a[i] = y[i + 1];
            this.function = function;
            this.FindCoefficients();
        }
        public Func<double, double> function { get; private set; }
        public double[] x { get; private set; }                        // табличные значения
        public double[] y { get; private set; }                        // табличные значения
        public double[] stepX { get; private set; }                    //x(i) - x(i-1)
        public double[] stepYdivStepX { get; private set; }            //(y(i) - y(i-1)) / stepX
        public double[] delta { get; private set; }                    //прогоночный коэффициент
        public double[] lambda { get; private set; }                   //прогоночный коэффициент
        public double[] a { get; private set; }                        // коэффициенты многочлена 3-й степени
        public double[] b { get; private set; }                        // 
        public double[] c { get; private set; }                        //
        public double[] d { get; private set; }                        //
    }
}
