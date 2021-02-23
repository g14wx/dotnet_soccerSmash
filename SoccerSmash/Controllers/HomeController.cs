using System;
using Microsoft.AspNetCore.Mvc;

namespace SoccerSmash
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            ViewBag.title = "Soccer Smash!";
            return View();
        }
    }
}