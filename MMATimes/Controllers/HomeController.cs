﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMATimes.Models;
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
            return View();
        }

        public IActionResult PostMessage()
        {
            //var newsService = new NewsService();


            return View();
        }

        public IActionResult PostNewStory(NewsStory newsStory)
        {
            if (!ModelState.IsValid)
                return BadRequest("No");

            try
            {
                using(NewsStory ctx = new Models.NewsStory())
                {

                }
            }

            return Ok()
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
