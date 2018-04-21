using System;
using System.Collections.Generic;
using OxyPlot;

namespace alg1wpf.view
{
    public class PointModel
    {
        public PointModel()
        {
            Title = "Зависимость времени от кол-ва вершин";
            Points = new List<DataPoint>();
            for (int i = 0; i < 100; i++)
            {
                Points.Add(new DataPoint(random.Next(10, 200), random.Next(100000, 10000000)));
            }
        }
        public Random random = new Random();
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
    }
}
