using System;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for PlotView.xaml
    /// </summary>
    public partial class PlotView : BasePage<PlotViewModel>, IDisposable
    {
        public PlotView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            (this.DataContext as PlotViewModel).Dispose();
        }
    }
}
