using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math4Wpf.Logical
{
    public static class DifferentialOperation
    {
        const int limit = 64 * 5;
        public static DifferentialFunctionContent SolveMiln(this DifferentialFunctionContent content)
        {
            bool isNext = true;
            while (isNext)
            {
                content.SolveRungeKutt(3);
                int count = content.X.Length;
                double predict;
                double step = Math.Abs((content.X[0] - content.X[count - 1])) / (count - 1);
                for (int i = 3; i < count - 1; i++)
                {
                    predict = content.Y[i - 3] + (4 / 3) * step *
                        (2 * content.function(content.X[i - 2], content.Y[i - 2]) -
                        content.function(content.X[i - 1], content.Y[i - 1]) +
                        2 * content.function(content.X[i], content.Y[i]));

                    content.Y[i + 1] = content.Y[i - 1] + (step / 3) *
                        (content.function(content.X[i - 1], content.Y[i - 1]) +
                        4 * content.function(content.X[i], content.Y[i]) +
                        content.function(content.X[i + 1], predict));
                    if (CheckPrecision(content.Y[i], predict, content.precision, CoefficientRunge.Miln))
                    {
                        if (content.countSplits >= limit)
                            throw new FunctionException("Невозможно достигнуть указанной точности");
                        isNext = true;
                        break;
                    }
                    isNext = false;
                }
            }
            return content;
        }
        public static DifferentialFunctionContent SolveUpMiln(this DifferentialFunctionContent content)
        {
            content.countSplits = 5;
            bool isNext = true;
            while (isNext)
            {
                content.SolveRungeKutt(3);
                int count = content.X.Length;
                double previousPredict = content.Y[3];
                double predict;
                double step = Math.Abs((content.X[0] - content.X[count - 1])) / (count - 1);
                double managerController;
                for (int i = 3; i < count - 1; i++)
                {
                    predict = content.Y[i - 3] + (4 / 3) * step *
                        (2 * content.function(content.X[i - 2], content.Y[i - 2]) -
                        content.function(content.X[i - 1], content.Y[i - 1]) +
                        2 * content.function(content.X[i], content.Y[i]));

                    managerController = predict +
                        (28 / 29) * (content.Y[i] - previousPredict);

                    content.Y[i + 1] = content.Y[i - 1] + (step / 3) *
                        (content.function(content.X[i - 1], content.Y[i - 1]) +
                        4 * content.function(content.X[i], content.Y[i]) +
                        content.function(content.X[i + 1], managerController));
                    if (CheckPrecision(content.Y[i], predict, content.precision, CoefficientRunge.Miln))
                    {
                        if (content.countSplits >= limit)
                            throw new FunctionException("Невозможно достигнуть указанной точности");
                        isNext = true;
                        break;
                    }
                    isNext = false;
                }
            }
            return content;
        }
        public static DifferentialFunctionContent SolveRungeKutt(this DifferentialFunctionContent content, int countValue)
        {
            bool isNext = true;
            double[] previousY = new double[countValue];
            content.Y = new double[countValue];
            for (int i = 0; i < countValue; i++)
                content.Y[i] = 0;
            while (isNext)
            {
                content.countSplits *= 2;
                for (int i = 0; i < countValue; i++)
                    previousY[i] = content.Y[i];
                content.X = new double[content.countSplits + 1];
                content.Y = new double[content.countSplits + 1];
                content.X[0] = content.xStart;
                content.Y[0] = content.yStart;
                content.X[content.countSplits] = content.xEnd;
                double step = Math.Abs((content.X[content.countSplits] - content.X[0])) / content.countSplits;
                for (int i = 0; i < content.countSplits - 1; i++)
                    content.X[i + 1] = content.X[i] + step;
                double coefficient1;
                double coefficient2;
                double coefficient3;
                double coefficient4;
                double deltaY;
                for (int i = 0; i < countValue; i++)
                {
                    coefficient1 = content.function(content.X[i], content.Y[i]);
                    coefficient2 = content.function(content.X[i] + step / 2,
                        content.Y[i] + step * coefficient1 / 2);
                    coefficient3 = content.function(content.X[i] + step / 2,
                        content.Y[i] + step * coefficient2 / 2);
                    coefficient4 = content.function(content.X[i] + step,
                        content.Y[i] + step * coefficient3);
                    deltaY = step / 6 * (coefficient1 + 2 * coefficient2 + 2 * coefficient3 + coefficient4);
                    content.Y[i + 1] = content.Y[i] + deltaY;
                    if (CheckPrecision(content.Y[i + 1], previousY[i], content.precision, CoefficientRunge.RungeKutt))
                    {
                        if (content.countSplits >= limit)
                            throw new FunctionException("Невозможно достигнуть указанной точности");
                        //if (content.X[1] - content.X[0] < 0.01)
                            //throw new FunctionException("Невозможно достигнуть указанной точности");
                        isNext = true;
                        break;
                    }
                    isNext = false;
                }
            }
            return content;
        }
        private static bool CheckPrecision(double currentValue, double previousValue, double precision, CoefficientRunge coefficient)
        {
            int order;
            switch (coefficient)
            {
                case CoefficientRunge.RungeKutt: { order = 15; break; }
                case CoefficientRunge.Miln: { order = 29; break; }
                default: { return false; }
            }
            double discrepancy = Math.Abs(currentValue - previousValue) / order;
            if (discrepancy > precision)
                return true;
            return false;
        }
    }
}
