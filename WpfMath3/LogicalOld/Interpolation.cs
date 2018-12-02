using System;
using System.Windows;

namespace WpfMath3.LogicalOld
{
    public static class Interpolation
    {
        static public FunctionContent FindCoefficients(this FunctionContent content)
        {
            try
            {
                int countPoint = content.x.Length;
                for (int i = 0; i < countPoint - 1; i++)
                {
                    if (content.x[i] > content.x[i + 1])
                        throw new FunctionException("Значения x д.б. в порядке возрастания");
                }
                for (int i = 1; i < countPoint; i++)
                {
                    content.stepX[i - 1] = content.x[i] - content.x[i - 1];
                    if (content.stepX[i - 1] == 0)
                        throw new FunctionException("Значения x не должны совпадать");
                    content.stepYdivStepX[i - 1] = (content.y[i] - content.y[i - 1]) / content.stepX[i - 1];
                }
                content.delta[0] = -content.stepX[1] / (2 * (content.stepX[0] + content.stepX[1]));
                content.lambda[0] = 1.5 * (content.stepYdivStepX[1] - content.stepYdivStepX[0]) / 
                    (content.stepX[0] + content.stepX[1]);
                for (int i = 2; i < countPoint - 1; i++)
                {
                    content.delta[i - 1] = -content.stepX[i] / 
                        (2 * content.stepX[i - 1] + 2 * content.stepX[i] + content.stepX[i - 1] * content.delta[i - 2]);
                    content.lambda[i - 1] = (3 * content.stepYdivStepX[i] - 
                        3 * content.stepYdivStepX[i - 1] - content.stepX[i - 1] * content.lambda[i - 2]) /
                        (2 * content.stepX[i - 1] + 2 * content.stepX[i] + content.stepX[i - 1] * content.delta[i - 2]);
                }
                content.c[countPoint - 2] = 0;
                for (int i = countPoint - 2; i > 0; i--)
                {
                    content.c[i - 1] = content.delta[i - 1] * content.c[i] + content.lambda[i - 1];
                }
                content.d[0] = (content.c[0]) / (3 * content.stepX[0]);
                content.b[0] = content.stepYdivStepX[0] + (2 * content.c[0] * content.stepX[0]) / 3;
                for (int i = 1; i < countPoint - 1; i++)
                {
                    content.d[i] = (content.c[i] - content.c[i - 1]) / (3 * content.stepX[i]);
                    content.b[i] = content.stepYdivStepX[i] + 
                        (2 * content.c[i] * content.stepX[i] + content.stepX[i] * content.c[i - 1]) 
                        / 3;
                }
                return content;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
