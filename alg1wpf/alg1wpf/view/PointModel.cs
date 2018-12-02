using System;
using System.Collections.Generic;
using OxyPlot;

namespace alg1wpf.view
{
    public class PointModel
    {
        public PointModel(List<int> time, int minEdge, int stepEdge) 
        {
            Title = "Зависимость времени от кол-ва вершин";
            Points = new List<DataPoint>();
            int countEdge = minEdge;
            for (int i = 0; i < time.Count; i++)
            {
                Points.Add(new DataPoint(countEdge, time[i]));
                countEdge += stepEdge;
            }
        }
        public Random random = new Random();
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
    }
}
