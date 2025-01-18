using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Views.Shared.Components._CommentListByBlogComponentPartial
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
