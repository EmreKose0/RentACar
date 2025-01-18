using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            var client = _httpClientFactory.CreateClient();  //istek için
            var responseMsg = await client.GetAsync("https://localhost:7039/api/Abouts");
            if (responseMsg.IsSuccessStatusCode)
            {
                var jsonData = await responseMsg.Content.ReadAsStringAsync();  //API den gelen veri Json formatta okunacak
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);  //APı den gelen json ı Model e mapledik Deserialize ettik DTO olsuturduk
                return View(values);
            }
            return View();
        }
    }
}
