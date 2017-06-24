using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace SmartApp.Views
{
    public partial class StocksView1 : ContentPage
    {
        public StocksView1()
        {
            InitializeComponent();
        }
        

        private void RadCartesianChart_NativeControlLoaded(object sender, System.EventArgs e)
        {
            if (!Device.RuntimePlatform.Equals("iOS"))
            {
                ((sender as RadCartesianChart).Series[0] as AreaSeries).StrokeThickness = 0;
            }
        }
    }
}
