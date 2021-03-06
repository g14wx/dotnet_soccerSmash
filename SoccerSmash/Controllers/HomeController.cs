using System;
using System.Collections.Generic;
using EFLib;
using EFLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace SoccerSmash
{
    public class HomeController: Controller
    {
        private MyDbContext _db;
        public HomeController(MyDbContext dbContext)
        {
            _db = dbContext;
        }
        [Route("/")]
        public ViewResult Index()
        {
            ViewBag.title = "Soccer Smash!";
            return View();
        }
    }
}