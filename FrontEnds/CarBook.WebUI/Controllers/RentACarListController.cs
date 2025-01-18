using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>Index(int id)
        {
            //var bookpickdate = TempData["bookpickdate"] ;
            //var bookoffdate = TempData["bookoffdate"] ;
            //var timepick = TempData["timepick"] ;
            //var timeoff = TempData["timeoff"] ;
            var locationID = TempData["locationID"] ;
            //ViewBag.bookpickdate = bookpickdate;
            //ViewBag.bookoffdate = bookoffdate;
            //ViewBag.timepick = timepick;
            //ViewBag.timeoff = timeoff;
            ViewBag.locationID = locationID;
            id = int.Parse(locationID.ToString()); 

            //filterRentACarDto.locationID = int.Parse(locationID.ToString());
            //filterRentACarDto.available = true;


            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync($"https://localhost:7039/api/RentACars?locationID={id}&available=true");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();



        }
    }
}
