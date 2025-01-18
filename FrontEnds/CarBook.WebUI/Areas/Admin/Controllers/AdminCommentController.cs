using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
   
        [Area("Admin")]
        [Route("Admin/AdminComment")]
        public class AdminCommentController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public AdminCommentController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            [Route("Index/{id}")]
            public async Task<IActionResult> Index(int id)
            {
            ViewBag.BlogId = id;
                var client = _httpClientFactory.CreateClient();
                var responseMsg = await client.GetAsync("https://localhost:7039/api/Comments/CommentListByBlog?id=" + id);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var jsonData = await responseMsg.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                    return View(values);
                }
                return View();
            }


            //[Route("RemoveComment/{id}")]
            //public async Task<IActionResult> RemoveComment(int id)
            //{
            //    var client = _httpClientFactory.CreateClient();
            //    var responseMsg = await client.DeleteAsync($"https://localhost:7039/api/Comments?id=" + id);
            //    if (responseMsg.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
            //    }
            //    return View();

            //}

            //CommentListByCommentID


        }
    
}
