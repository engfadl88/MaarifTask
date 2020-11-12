using News.Service;
using News.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            var newsViewModelList = _newsService.GetNews();

            return View(newsViewModelList);
        }

    }
}