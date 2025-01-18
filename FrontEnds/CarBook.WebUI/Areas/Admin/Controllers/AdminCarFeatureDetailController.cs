using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("https://localhost:7039/api/CarFeatures?id="+id);
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> listResultCarFeature)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in listResultCarFeature)
            {
                if (item.available)
                {

                    await client.GetAsync("https://localhost:7039/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" +  item.carFeatureID);
                }
                else
                {

                    await client.GetAsync("https://localhost:7039/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.carFeatureID);
                }
               
            }
            return RedirectToAction("Index","AdminCar");
        }


        [Route("CreateFeatureByCar")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("https://localhost:7039/api/Features");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
