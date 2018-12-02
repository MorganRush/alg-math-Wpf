    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math4Wpf.Logical
{
    public enum CoefficientRunge { RungeKutt, Miln }
    public class DifferentialFunctionContent :IFunctionContent
    {
        public Func<double, double, double> function;
        public double xStart;
        public double xEnd;
        public double yStart;
        public double precision;
        public int countSplits;
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public double[] CoefficientA { get; set; }
        public double[] CoefficientB { get; set; }
        public double[] CoefficientC { get; set; }
        public double[] CoefficientD { get; set; }
        public DifferentialFunctionContent(double xStart, double xEnd, double yStart, double precision, int countSplits, Func<double, double, double> function)
        {
            this.xStart = xStart;
            this.xEnd = xEnd;
            this.yStart = yStart;
            this.function = function;
            this.precision = precision;
            this.countSplits = countSplits;
            this.SolveUpMiln();
            int size = this.X.Length;
            CoefficientA = new double[size - 1];
            CoefficientB = new double[size - 1];
            CoefficientC = new double[size - 1];
            CoefficientD = new double[size - 1];
            this.FindCoefficients();
        }
    }
}
