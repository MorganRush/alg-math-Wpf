using OxyPlot;
using OxyPlot.Series;
using System;
using Math4Wpf.Logical;

namespace Math4Wpf.View
{
    public class InterpolationModel
    {
        public InterpolationModel(DifferentialFunctionContent content)
        {
            this.model = new PlotModel() { Title = "Интерполяция" };
            int size = content.X.Length;
            //this.model.Series.Add(new FunctionSeries(content.Function, content.X[0], content.X[size - 1], 0.1, "Исходная ф-я"));
            for (int i = 0; i < size - 1; i++)
            {
                this.model.Series.Add(new FunctionSeries(x => content.CoefficientA[i] +
                content.CoefficientB[i] * (x - content.X[i + 1]) +
                content.CoefficientC[i] * Math.Pow((x - content.X[i + 1]), 2) +
                content.CoefficientD[i] * Math.Pow((x - content.X[i + 1]), 3),
                    content.X[i], content.X[i + 1], 0.001));
            }
            for (int i = 0; i < this.model.DefaultColors.Count; i++)
                this.model.DefaultColors[i] = OxyColors.Black;
        }
        public PlotModel model { get; private set; }
    }
}
