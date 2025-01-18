using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsCompenentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsCompenentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region CarCount 

            var random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCount");
            if (responseMsg.IsSuccessStatusCode)
            {
                var v1 = random.Next(0, 100);
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v1 = values.carCount;
                ViewBag.v11 = v1;
            }
            #endregion

            #region LocationCount 

            var responseMsg2 = await client.GetAsync("https://localhost:7039/api/Statistics/GetLocationCount");
            if (responseMsg2.IsSuccessStatusCode)
            {
                var v2 = random.Next(0, 100);
                var jsonData2 = await responseMsg2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.v2 = values2.locationCount;
                ViewBag.v22 = v2;
            }
            #endregion

           

            

            #region BrandCpunt
            var responseMsg5 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBrandCount");
            if (responseMsg5.IsSuccessStatusCode)
            {
                var v5 = random.Next(0, 100);
                var jsonData5 = await responseMsg5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.v5 = values5.brandCount;
                ViewBag.v55 = v5;
            }
            #endregion

            #region GetAvgRentPriceForDaily
            var responseMsg6 = await client.GetAsync("https://localhost:7039/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMsg6.IsSuccessStatusCode)
            {
                var v6 = random.Next(0, 100);
                var jsonData6 = await responseMsg6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.v6 = values6.avgRentPriceForDaily.ToString("0,00");
                ViewBag.v66 = v6;
            }
            #endregion

          
            return View();
        }

    }
}
