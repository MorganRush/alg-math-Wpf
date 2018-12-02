using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMath3.Logical
{
    public class DifferentialFunctionContent :IFunctionContent
    {
        public Func<double, double, double> Function { get; set; }
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public double[] CoefficientA { get; set; }
        public double[] CoefficientB { get; set; }
        public double[] CoefficientC { get; set; }
        public double[] CoefficientD { get; set; }
        public DifferentialFunctionContent(double[] x, double y, Func<double, double, double> function)
        {
            int size = x.Length;
            this.X = new double[size];
            this.Y = new double[size];
            for (int i = 0; i < size; i++)
                this.X[i] = x[i];
            this.Y[0] = y;
            this.Function = function;
            this.SolveMiln();
            for (int i = 0; i < size - 1; i++)
                CoefficientA[i] = this.Y[i + 1];
            this.FindCoefficients();
            CoefficientA = new double[size - 1];
            CoefficientB = new double[size - 1];
            CoefficientC = new double[size - 1];
            CoefficientD = new double[size - 1];
        }
    }
}
