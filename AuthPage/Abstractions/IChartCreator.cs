using AuthPage.Models;
using Blazorise.Charts;

namespace AuthPage.Abstractions
{
    public interface IChartCreator
    {
        public Task<PieChart<double>> InitializeChart();
        public Task<IEnumerable<AppChartModel>> LoadData();
        public PieChartDataset<double> GetChartDataset(IEnumerable<AppChartModel> appCharts);
    }
}
