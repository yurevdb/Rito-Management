using OxyPlot;
using OxyPlot.Series;

namespace ServerControl
{
    /// <summary>
    /// Extension methods for plotmodels in oxyplot
    /// </summary>
    public static class PlotmodelHelper
    {
        /// <summary>
        /// This method updates the lineseries of the plot with the data given.
        /// The lineseries of the plotmodel will hold at most 60 points.
        /// </summary>
        /// <param name="plot">The plot to update</param>
        /// <param name="interval">The interval of time passed</param>
        /// <param name="data">The data to display</param>
        public static void Update(this BasePlotModel plot, params double[] data)
        {
            plot.CountUp();
            int seriesnumber = 0;
            foreach (double info in data)
            {
                (plot.Series[seriesnumber] as LineSeries).Points.Add(new DataPoint(plot.Count, info));
                if ((plot.Series[seriesnumber] as LineSeries).Points.Count > 60)
                    (plot.Series[seriesnumber] as LineSeries).Points.RemoveAt(0);
                seriesnumber++;
            }
            plot.InvalidatePlot(true);
        }

        /// <summary>
        /// Method to add 1 to the <see cref="BasePlotModel.Count"/> of the <see cref="BasePlotModel"/>.
        /// </summary>
        /// <param name="plot">The <see cref="BasePlotModel"/> up the <see cref="BasePlotModel.Count"/></param>
        /// <param name="number">A <see cref="double"/> to add to the <see cref="BasePlotModel.Count"/> property</param>
        public static void CountUp(this BasePlotModel plot, double number = 1)
        {
            plot.Count = plot.Count + number;
        }

        /// <summary>
        /// Method to reset <see cref="BasePlotModel.Count"/> of the <see cref="BasePlotModel"/>
        /// </summary>
        /// <param name="plot">The <see cref="BasePlotModel"/> to reset the count of.</param>
        public static void ResetCount(this BasePlotModel plot)
        {
            plot.Count = 0;
        }

    }
}
