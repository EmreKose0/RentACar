using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public BlogController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Bloglarımız:";
            var client = _httpclientFactory.CreateClient();
            var responsemsg = await client.GetAsync("https://localhost:7039/api/Blogs/GetAllBlogsWithAuthor");
            if (responsemsg.IsSuccessStatusCode)
            {
                var jsonData = await responsemsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            var client = _httpclientFactory.CreateClient();

            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.BlogId = id;
            var responsemsg2 = await client.GetAsync($"https://localhost:7039/api/Comments/CommentCountByBlog?id=" + id);
            if (responsemsg2.IsSuccessStatusCode)
            {
                var jsonData2 = await responsemsg2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<string>(jsonData2);
                ViewBag.commentCount = values2;
            }
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentx(CreateCommentDto createCommentDto)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMsg = await client.PostAsync("https://localhost:7039/api/CreateCommentWithMediator", stringContent);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
