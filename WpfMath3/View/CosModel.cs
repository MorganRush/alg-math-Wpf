using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace WpfMath3
{
    public class CosModel
    {
        public CosModel()
        {
            this.model = new PlotModel { Title = "Example1" };
            //this.model1 = new PlotModel { Title = "Example2" };
            this.model.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this.model.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
            this.model.Series.Add(new FunctionSeries(x => x, 0, 10, 0.1));
        }
        public PlotModel model { get; private set; }
        //public PlotModel model1 { get; private set; }
    }
}
