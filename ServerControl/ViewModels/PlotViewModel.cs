using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;

namespace ServerControl
{
    public class PlotViewModel: BaseViewModel, IDisposable
    {
        #region Plotmodels

        /// <summary>
        /// The plotmodel to plot the cpu usage data of the server
        /// </summary>
        public BasePlotModel CpuPlot { get; set; }

        /// <summary>
        /// The plotmodel to plot the ram usage data of the server
        /// </summary>
        public BasePlotModel RamPlot { get; set; }

        /// <summary>
        /// The plotmodel to plot the network usage of the server
        /// </summary>
        public BasePlotModel NetPlot { get; set; }

        #endregion

        #region Constructor (method for construction)

        /// <summary>
        /// Setting up the plots
        /// </summary>
        private void SetupModels()
        {
            //creating the cpu usage plotmodel
            CpuPlot = new BasePlotModel();
            CpuPlot.Title = "Cpu Usage";
            CpuPlot.IsLegendVisible = true;
            CpuPlot.Axes.Add(new LinearAxis() { Minimum = 0, Maximum = 100, Position = AxisPosition.Left, IsZoomEnabled = false });
            CpuPlot.Axes.Add(new LinearAxis() { TextColor = OxyColors.Transparent, Position = AxisPosition.Bottom, TickStyle = TickStyle.None, IsZoomEnabled = false });
            LineSeries lsc = new LineSeries();
            lsc.Color = OxyColors.DodgerBlue;
            lsc.Title = "% CPU Usage";
            CpuPlot.Series.Add(lsc);

            //creating the ram usage plotmodel
            RamPlot = new BasePlotModel();
            RamPlot.Title = "Ram Usage";
            RamPlot.IsLegendVisible = true;
            RamPlot.Axes.Add(new LinearAxis() { Minimum = 0, Maximum = 100, Position = AxisPosition.Left, IsZoomEnabled = false });
            RamPlot.Axes.Add(new LinearAxis() { TextColor = OxyColors.Transparent, Position = AxisPosition.Bottom, TickStyle = TickStyle.None, IsZoomEnabled = false });
            LineSeries lsr = new LineSeries();
            lsr.Title = "% RAM Usage";
            lsr.Color = OxyColors.MediumPurple;
            RamPlot.Series.Add(lsr);

            //creating the network usage plotmodel
            NetPlot = new BasePlotModel();
            NetPlot.Title = "Network Usage";
            NetPlot.IsLegendVisible = true;
            NetPlot.Axes.Add(new LinearAxis() { MinimumRange = 50, AbsoluteMinimum = 0, Position = AxisPosition.Left, IsZoomEnabled = false });
            NetPlot.Axes.Add(new LinearAxis() { TextColor = OxyColors.Transparent, Position = AxisPosition.Bottom, TickStyle = TickStyle.None, IsZoomEnabled = false });
            LineSeries ls_sent = new LineSeries();
            LineSeries ls_recv = new LineSeries();
            ls_sent.Color = OxyColors.OrangeRed;
            ls_sent.Title = "kB/s Sent";
            ls_recv.Color = OxyColors.ForestGreen;
            ls_recv.Title = "kB/s Received";
            NetPlot.Series.Add(ls_sent);
            NetPlot.Series.Add(ls_recv);
        }

        /// <summary>
        /// Setting up the model for the plots
        /// </summary>
        private async void InitializePlot()
        {
            await PlotDataModel.SetupPlotmodels();
            PlotDataModel.serverStats.ServerDataAvailable += (sender, e) => UpdatePlots(e.Data);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlotViewModel()
        {
            SetupModels();
            InitializePlot();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Function to update the plots
        /// </summary>
        /// <param name="data">The data to show</param>
        private void UpdatePlots(double[] data)
        {
            CpuPlot.Update(data[0]);
            RamPlot.Update(data[1]);
            NetPlot.Update(data[2], data[3]);
        }

        /// <summary>
        /// Function to dispose of the plots
        /// </summary>
        public void Dispose()
        {
            CpuPlot.Dispose();
            RamPlot.Dispose();
            NetPlot.Dispose();
        }

        #endregion
    }
}
