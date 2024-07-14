using AuthPage.Abstractions;
using AuthPage.Models;
using Blazorise.Charts;
using Blazorise;

namespace AuthPage.Implemenatations
{
    public class SaftyChartCreator : IChartCreator
    {
        PieChart<double> pieChart;
        IHttpService httpService;
        public async Task<PieChart<double>> InitializeChart()
        {
            pieChart = new PieChart<double>();

            IEnumerable<AppChartModel> appChartModel = await LoadData();

            await pieChart.AddLabelsDatasetsAndUpdate(appChartModel.Select(x => x.label).ToArray(), GetChartDataset(appChartModel));

            return pieChart;
        }
        public async Task<IEnumerable<AppChartModel>> LoadData()
        {
            //return await httpService.Get<IEnumerable<AppChartModel>>("/chart/GetSaftyChart");
            var saftyChartItems = new List<AppChartModel>
            {
                new AppChartModel { label = "Не выбрано", value = 1233 },
                new AppChartModel { label = "Аптечки", value = 31 },
                new AppChartModel { label = "НДС", value = 444 },
                new AppChartModel { label = "Оборудование", value = 100 }
            };
            return saftyChartItems.AsEnumerable();
        }

        public PieChartDataset<double> GetChartDataset(IEnumerable<AppChartModel> appCharts)
        {
            return new()
            {
                Label = "График по типологии нарушений",
                Data = appCharts.Select(x => x.value).ToList(),
                BorderWidth = 1
            };
        }
    }
}
