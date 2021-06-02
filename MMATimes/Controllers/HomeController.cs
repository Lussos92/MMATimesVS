using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMATimes.Models;
using NewsService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MMATimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            NewsHomeModel model = new NewsHomeModel();
            MMATimes_MainContext context = new MMATimes_MainContext();
            foreach(var newsContext in context.NewsStories)
            {
                NewsStoryModel newsStory = new NewsStoryModel
                {
                    Blurb = newsContext.Blurb,
                    MainBody = newsContext.MainBody,
                    Title = newsContext.Title
                };
                model.NewsStories.Add(newsStory);
            }
            return View(model);
        }

        public IActionResult PostMessage()
        {
            //var newsService = new NewsService();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
