using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _BlogDetailsCategoryComponentPartial(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responsemsg = await client.GetAsync("https://localhost:7039/api/Categories");
            if (responsemsg.IsSuccessStatusCode)
            {
                var jsonData = await responsemsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
