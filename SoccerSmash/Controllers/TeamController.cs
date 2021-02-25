using System.Collections.Generic;
using System.Linq;
using EFLib;
using EFLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace SoccerSmash
{
    public class TeamController: Controller
    {
        private MyDbContext _db;
        public TeamController(MyDbContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet]
        [Route("/teams")]
        public ViewResult Index()
        {
            List<Team> listTeam = _db.Teams.ToList<Team>(); 
            return View(listTeam);
        }
    }
}