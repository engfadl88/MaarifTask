using News.Service;
using News.Service.ViewModels;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: News/Add
        public ActionResult Add()
        {
            ViewBag.CurrentLang = CultureInfo.CurrentCulture.Name;
;
            ViewBag.Schools = LookupsData.Schools;

            return View();
        }

        // POST: News/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewsViewModel newsViewModel, HttpPostedFileBase image, HttpPostedFileBase file)
        {
            ViewBag.Schools = LookupsData.Schools;

            if (!ModelState.IsValid)
            {
                return View(newsViewModel);
            }

            // Check news image
            if (image != null && image.ContentType.Contains("image"))
            {
                image.SaveAs(HttpContext.Server.MapPath("~/images/") + image.FileName);
                newsViewModel.NewsImage = image.FileName;
            }
            else
            {
                TempData["error"] = "News Image: File Extension Is InValid - Only Upload Images";
                return View(newsViewModel);
            }

            // Check attachment
            var supportedTypes = new[] { "doc", "docx", "ppt", "pptx" };
            var fileExt = Path.GetExtension(file.FileName).Substring(1);
            if (!supportedTypes.Contains(fileExt))
            {
                TempData["error"] = "Attachment: File Extension Is InValid - Only Upload WORD/Power Point files";
                return View(newsViewModel);
            }
            else
            {
                file.SaveAs(HttpContext.Server.MapPath("~/attachments/") + file.FileName);
                newsViewModel.Attachment = file.FileName;
            }
            
            // Using dependency injection to save news data
            var result = _newsService.AddNews(newsViewModel);

            if (result.IsValid)
            {
                TempData["success"] = "News is saved successfully";
                return RedirectToAction("Add", "News");
            }
            else
            {
                TempData["error"] = result.FirstErrorMessage;
                return View(newsViewModel);
            }
        }

        // GET: News/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var requestVM = _newsService.GetNewsById(id.Value);

            return View(requestVM);
        }
    }
}