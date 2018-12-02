using System;
using System.Collections.Generic;
using Math4Wpf.Logical;
using OxyPlot;

namespace Math4Wpf.View
{
    public class PointModel
    {
        public PointModel(DifferentialFunctionContent content)
        {
            this.Title = "Интерполяция";
            this.Points = new List<DataPoint>();
            for (int i = 0; i < content.X.Length; i++)
            {
                this.Points.Add(new DataPoint(content.X[i], content.Y[i]));
            }
        }
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
    }
}
