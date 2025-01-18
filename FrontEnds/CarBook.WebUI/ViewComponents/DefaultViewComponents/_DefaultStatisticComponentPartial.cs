using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region CarCount 

            var responseMsg = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCount");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion
            #region BrandCpunt
            var responseMsg5 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBrandCount");
            if (responseMsg5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMsg5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;
            }
            #endregion
            #region GetCarCountByFuelElectric
            var responseMsg113 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByFuelElectric");
            if (responseMsg113.IsSuccessStatusCode)
            {
                var jsonData113 = await responseMsg113.Content.ReadAsStringAsync();
                var values113 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData113);
                ViewBag.electricCar = values113.carCountByFuelElectric;
            }
            #endregion
            #region GetCarCountByTransmissionIsAuto
            var responseMsg9 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMsg9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMsg9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.auto = values9.carCountByTransmissionIsAuto;
            }
            #endregion
            return View();
        }
    }
}
