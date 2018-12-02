using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMath3.Logical
{
    public static class DifferentialEquations
    {
        public static DifferentialFunctionContent SolveMiln(this DifferentialFunctionContent content)
        {
            content.SolveRungeCutt(3);
            int count = content.X.Length;
            double[] predict = new double[count];
            for (int i = 0; i < 4; i++)
                predict[i] = content.X[i];
            double step = Math.Abs((content.X[0] - content.X[count - 1])) / (count - 1);
            double managerController;
            Console.WriteLine(step);
            for (int i = 3; i < count - 1; i++)
            {
                predict[i + 1] = content.Y[i - 3] + (4 / 3) * step *
                    (2 * content.Function(content.X[i - 2], content.Y[i - 2]) -
                    content.Function(content.X[i - 1], content.Y[i - 1]) +
                    2 * content.Function(content.X[i], content.Y[i]));

                managerController = predict[i + 1] +
                    (28 / 29) * (content.Y[i] - predict[i]);

                content.Y[i + 1] = content.Y[i - 1] + (step / 3) *
                    (content.Function(content.X[i - 1], content.Y[i - 1]) +
                    4 * content.Function(content.X[i], content.Y[i]) +
                    content.Function(content.X[i + 1], managerController));
            }
            return content;
        }
        public static DifferentialFunctionContent SolveRungeCutt(this DifferentialFunctionContent content, int countValue)
        {
            int count = content.X.Length;
            double step = Math.Abs((content.X[count - 1] - content.X[0])) / (count - 1);
            double coefficient1;
            double coefficient2;
            double coefficient3;
            double coefficient4;
            double deltaY;
            for (int i = 0; i < countValue; i++)
            {
                coefficient1 = content.Function(content.X[i], content.Y[i]);
                coefficient2 = content.Function(content.X[i] + step / 2,
                    content.Y[i] + step * coefficient1 / 2);
                coefficient3 = content.Function(content.X[i] + step / 2,
                    content.Y[i] + step * coefficient2 / 2);
                coefficient4 = content.Function(content.X[i] + step,
                    content.Y[i] + step * coefficient3);
                deltaY = step / 6 * (coefficient1 + 2 * coefficient2 + 2 * coefficient3 + coefficient4);
                content.Y[i + 1] = content.Y[i] + deltaY;
            }
            return content;
        }
    }
}
