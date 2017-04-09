using OxyPlot;
using OxyPlot.Series;
using System;

namespace ServerControl.Core
{
    public class BasePlotModel: PlotModel, IDisposable
    {
        public double Count { get; set; }

        public void Dispose()
        {
            foreach (LineSeries series in this.Series)
                series.ClearSelection();
            this.ResetCount();
        }
    }
}
