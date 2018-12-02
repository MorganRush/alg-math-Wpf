using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using Math4Wpf.Logical;

namespace Math4Wpf.View
{
    class PointPlotModel
    {
        public PointPlotModel(DifferentialFunctionContent content)
        {
            this.model = new PlotModel() { Title = "Интерполяция" };
            int size = content.X.Length;
            //this.model.Series.Add(new FunctionSeries(content.Function, content.X[0], content.X[size - 1], 0.1, "Исходная ф-я"));
            for (int i = 0; i < size - 1; i++)
            {
                this.model.Series.Add(new FunctionSeries(x => 
                (x - content.X[i]) * (content.Y[i+1] - content.Y[i]) / (content.X[i + 1] - content.X[i]) 
                + content.Y[i],
                    content.X[i], content.X[i + 1], 0.01));
            }
            for (int i = 0; i < this.model.DefaultColors.Count; i++)
                this.model.DefaultColors[i] = OxyColors.Black;
        }
        public PlotModel model { get; private set; }
    }
}
