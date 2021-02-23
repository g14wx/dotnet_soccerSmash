using System;
using Microsoft.AspNetCore.Mvc;

namespace SoccerSmash
{
    public class HomeController: Controller
    {
        [Route("/")]
        public ViewResult Index()
        {
            ViewBag.title = "Soccer Smash!";
            return View();
        }
    }
}